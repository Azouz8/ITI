import 'package:chat_app/features/chat/data/models/message_model.dart';
import 'package:dart_either/dart_either.dart';

abstract class ChatRepo {
  Future<Either<String, void>> sendMessage({
    required String chatId,
    required MessageModel message,
  });

  Stream<List<MessageModel>> getMessages({required String chatId});
}
