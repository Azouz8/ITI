import 'dart:async';

import 'package:chat_app/features/chat/data/models/message_model.dart';
import 'package:chat_app/features/chat/data/repos/chat_repo.dart';
import 'package:chat_app/features/chat/presentation/manager/chat_states.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ChatCubit extends Cubit<ChatStates> {
  ChatCubit(this.chatRepo) : super(ChatInitial());
  final ChatRepo chatRepo;

  static ChatCubit get(BuildContext context) =>
      BlocProvider.of<ChatCubit>(context);

  StreamSubscription<List<MessageModel>>? _messagesSubscription;
  List<MessageModel> _messages = [];

  void listenToMessages({required String chatId}) {
    emit(MessagesLoadingState());
    _messagesSubscription?.cancel();
    _messagesSubscription = chatRepo.getMessages(chatId: chatId).listen(
      (messages) {
        debugPrint('Received ${messages.length} messages at ${DateTime.now()}');
        _messages = messages;
        emit(MessagesLoadedState(messages: messages));
      },
      onError: (error) => emit(MessagesErrorState(error: error.toString())),
    );
  }

  Future<void> sendMessage({
    required String chatId,
    required String senderId,
    required String text,
  }) async {
    if (text.trim().isEmpty) return;
    emit(SendMessageLoadingState());

    final message = MessageModel(
      senderId: senderId,
      text: text,
      sentAt: DateTime.now(),
    );

    final result = await chatRepo.sendMessage(chatId: chatId, message: message);
    result.fold(
      ifLeft: (error) => emit(SendMessageFailState(error: error)),
      ifRight: (value) => emit(SendMessageSuccessState()),
    );
    emit(MessagesLoadedState(messages: _messages));
  }

  @override
  Future<void> close() {
    _messagesSubscription?.cancel();
    return super.close();
  }
}
