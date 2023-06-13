part of 'initial_bloc.dart';

@freezed
class InitialEvent with _$InitialEvent {
  /// Определение следующего роута
  const factory InitialEvent.resolveNextRoute() = ResolveNextRoute;
}
