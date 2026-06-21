import 'package:chat_app/features/chat/data/models/message_model.dart';
import 'package:chat_app/features/chat/data/repos/chat_repo.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:dart_either/src/dart_either.dart';

class ChatRepoImpl extends ChatRepo {
  final FirebaseFirestore firestore;

  ChatRepoImpl({FirebaseFirestore? firestore})
    : firestore = firestore ?? FirebaseFirestore.instance;

  @override
  Stream<List<MessageModel>> getMessages({required String chatId}) {
    return firestore
        .collection('chats')
        .doc(chatId)
        .collection('messages')
        .orderBy('sentAt')
        .snapshots()
        .map(
          (snapshot) => snapshot.docs
              .map((doc) => MessageModel.fromMap(doc.data()))
              .toList(),
        );
  }

  @override
  Future<Either<String, void>> sendMessage({
    required String chatId,
    required MessageModel message,
  }) async {
    try {
      await firestore
          .collection("chats")
          .doc(chatId)
          .collection("messages")
          .add(message.toMap());
      return const Right(null);
    } catch (e) {
      return Left(e.toString());
    }
  }
}
