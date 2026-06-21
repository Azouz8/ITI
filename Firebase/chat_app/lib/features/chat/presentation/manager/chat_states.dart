import 'package:chat_app/features/chat/data/models/message_model.dart';

abstract class ChatStates {}

class ChatInitial extends ChatStates {}

class MessagesLoadingState extends ChatStates {}

class MessagesLoadedState extends ChatStates {
  final List<MessageModel> messages;

  MessagesLoadedState({required this.messages});
}

class MessagesErrorState extends ChatStates {
  final String error;
  MessagesErrorState({required this.error});
}

class SendMessageLoadingState extends ChatStates {}

class SendMessageSuccessState extends ChatStates {}

class SendMessageFailState extends ChatStates {
  final String error;
  SendMessageFailState({required this.error});
}
