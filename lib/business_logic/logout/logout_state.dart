part of 'logout_bloc.dart';

@freezed
class LogoutState with _$LogoutState {
  const factory LogoutState.logoutInitial() = LogoutInitial;
  const factory LogoutState.logoutLoading() = LogoutLoading;
  const factory LogoutState.logoutSuccess() = LogoutSuccess;
}
