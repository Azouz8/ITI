import 'package:chat_app/core/themes/dark_theme/app_colors_dark.dart';
import 'package:chat_app/core/themes/light_theme/app_colors_light.dart';
import 'package:chat_app/features/authentication/presentation/manager/auth_cubit/auth_cubit.dart';
import 'package:chat_app/features/authentication/presentation/manager/auth_cubit/auth_states.dart';
import 'package:chat_app/features/chat/data/models/message_model.dart';
import 'package:chat_app/features/chat/data/repos/chat_repo_impl.dart';
import 'package:chat_app/features/chat/presentation/manager/chat_cubit.dart';
import 'package:chat_app/features/chat/presentation/manager/chat_states.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:heroicons/heroicons.dart';
import 'package:intl/intl.dart';

class ChatScreen extends StatelessWidget {
  ChatScreen({super.key, required this.chatId});

  final String chatId;
  final messageController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;
    final textTheme = Theme.of(context).textTheme;
    final currentUserId = FirebaseAuth.instance.currentUser!.uid;

    return BlocProvider(
      create: (context) =>
          ChatCubit(ChatRepoImpl())..listenToMessages(chatId: chatId),
      child: BlocBuilder<ChatCubit, ChatStates>(
        builder: (context, state) {
          final messages = state is MessagesLoadedState
              ? state.messages
              : <MessageModel>[];
          final isSending = state is SendMessageLoadingState;

          return GestureDetector(
            onTap: () => FocusManager.instance.primaryFocus?.unfocus(),
            behavior: HitTestBehavior.opaque,
            child: Scaffold(
              appBar: AppBar(
                title: Text("Chat Name", style: textTheme.titleLarge),
                actions: [
                  BlocBuilder<AuthCubit, AuthStates>(
                    builder: (context, authState) {
                      return Container(
                        margin: const EdgeInsets.only(right: 12),
                        child: ClipRRect(
                          borderRadius: BorderRadius.circular(28),
                          child: InkWell(
                            onTap: () => AuthCubit.get(context).logoutUser(),
                            borderRadius: BorderRadius.circular(28),
                            child: Padding(
                              padding: const EdgeInsets.all(12),
                              child: authState is LogoutLoadingState
                                  ? SizedBox(
                                      height: 24,
                                      width: 24,
                                      child: CircularProgressIndicator(
                                        strokeWidth: 2,
                                        color: colorScheme.primary,
                                      ),
                                    )
                                  : const HeroIcon(
                                      HeroIcons.arrowRightStartOnRectangle,
                                      size: 28,
                                      color: Colors.redAccent,
                                    ),
                            ),
                          ),
                        ),
                      );
                    },
                  ),
                ],
              ),
              body: Column(
                children: [
                  Expanded(
                    child: Container(
                      margin: const EdgeInsets.all(8),
                      padding: const EdgeInsets.symmetric(vertical: 8),
                      decoration: BoxDecoration(
                        color: Theme.of(context).brightness == Brightness.dark
                            ? const Color.fromARGB(255, 33, 49, 63)
                            : AppColorsLight.chatBackgroundColor,
                        borderRadius: BorderRadius.circular(16),
                      ),
                      child: ListView.builder(
                        physics: const BouncingScrollPhysics(),
                        reverse: true,
                        itemCount: messages.length,
                        itemBuilder: (context, index) {
                          final message = messages[messages.length - 1 - index];
                          final isMe = message.senderId == currentUserId;
                          return Align(
                            alignment: isMe
                                ? Alignment.centerRight
                                : Alignment.centerLeft,
                            child: Container(
                              margin: const EdgeInsets.symmetric(
                                horizontal: 12,
                                vertical: 4,
                              ),
                              padding: const EdgeInsets.symmetric(
                                horizontal: 14,
                                vertical: 10,
                              ),
                              decoration: BoxDecoration(
                                color: isMe
                                    ? colorScheme.primary
                                    : colorScheme.surface,
                                borderRadius: BorderRadius.circular(16),
                              ),
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.end,
                                children: [
                                  Text(
                                    message.text,
                                    style: textTheme.bodyLarge?.copyWith(
                                      color: isMe
                                          ? colorScheme.onPrimary
                                          : colorScheme.onSurface,
                                    ),
                                  ),

                                  Text(
                                    DateFormat('h:mm a').format(message.sentAt),
                                    style: textTheme.labelSmall?.copyWith(
                                      color: isMe
                                          ? colorScheme.onPrimary
                                          : colorScheme.onSurface,
                                    ),
                                  ),
                                ],
                              ),
                            ),
                          );
                        },
                      ),
                    ),
                  ),
                  SafeArea(
                    top: false,
                    child: Padding(
                      padding: const EdgeInsets.fromLTRB(12, 8, 12, 12),
                      child: Row(
                        crossAxisAlignment: CrossAxisAlignment.end,
                        children: [
                          Expanded(
                            child: ConstrainedBox(
                              constraints: const BoxConstraints(maxHeight: 120),
                              child: TextField(
                                controller: messageController,
                                minLines: 1,
                                maxLines: 5,
                                textCapitalization:
                                    TextCapitalization.sentences,
                                style: textTheme.bodyLarge,
                                decoration: InputDecoration(
                                  hintText: "Type a message...",
                                  hintStyle: textTheme.bodyMedium?.copyWith(
                                    color: colorScheme.onSurface.withAlpha(120),
                                  ),
                                  filled: true,
                                  fillColor: colorScheme.surface,
                                  contentPadding: const EdgeInsets.symmetric(
                                    horizontal: 18,
                                    vertical: 12,
                                  ),
                                  border: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(24),
                                    borderSide: BorderSide.none,
                                  ),
                                  enabledBorder: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(24),
                                    borderSide: BorderSide(
                                      color: colorScheme.onSurface.withAlpha(
                                        40,
                                      ),
                                      width: 1,
                                    ),
                                  ),
                                  focusedBorder: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(24),
                                    borderSide: BorderSide(
                                      color: colorScheme.primary,
                                      width: 1.5,
                                    ),
                                  ),
                                ),
                              ),
                            ),
                          ),
                          const SizedBox(width: 8),
                          Container(
                            decoration: BoxDecoration(
                              shape: BoxShape.circle,
                              color: isSending
                                  ? colorScheme.onSurface.withAlpha(40)
                                  : colorScheme.primary,
                            ),
                            child: IconButton(
                              onPressed: isSending
                                  ? null
                                  : () {
                                      final text = messageController.text;
                                      if (text.trim().isEmpty) return;
                                      ChatCubit.get(context).sendMessage(
                                        chatId: chatId,
                                        senderId: currentUserId,
                                        text: text,
                                      );
                                      messageController.clear();
                                    },
                              icon: const HeroIcon(
                                HeroIcons.paperAirplane,
                                size: 22,
                              ),
                              color: colorScheme.onPrimary,
                              splashRadius: 24,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
