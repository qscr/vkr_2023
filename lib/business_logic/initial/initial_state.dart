part of 'initial_bloc.dart';

@freezed
class InitialState with _$InitialState {
  const factory InitialState.initial() = Initial;
  const factory InitialState.loadInProgress() = LoadInProgress;
  const factory InitialState.goToLogin() = GoToLogin;
  const factory InitialState.goToApp() = GoToApp;
  const factory InitialState.goToWebGeneratorLogin() = GoToWebGeneratorLogin;
  const factory InitialState.goToWebGeneratorApp() = GoToWebGeneratorApp;
}
