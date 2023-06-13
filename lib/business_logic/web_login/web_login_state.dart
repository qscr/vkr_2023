part of 'web_login_bloc.dart';

@freezed
class WebLoginState with _$WebLoginState {
  const factory WebLoginState.initial() = Initial;
  const factory WebLoginState.loadInProgress() = LoginLoading;
  const factory WebLoginState.loginSuccess() = LoginSuccess;

  @Implements<BaseErrorState>()
  const factory WebLoginState.loginError(String message) = LoginError;
}
