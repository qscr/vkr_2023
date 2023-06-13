part of 'web_login_bloc.dart';

@freezed
class WebLoginEvent with _$WebLoginEvent {
  const factory WebLoginEvent.login({
    required String email,
    required String password,
  }) = Login;
}
