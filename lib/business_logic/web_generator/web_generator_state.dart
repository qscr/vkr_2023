part of 'web_generator_bloc.dart';

@freezed
class WebGeneratorState with _$WebGeneratorState {
  const factory WebGeneratorState.initial() = Initial;
  const factory WebGeneratorState.loading() = Loading;
  const factory WebGeneratorState.uploadingSuccess() = UploadingSuccess;
  const factory WebGeneratorState.uploadingError() = UploadingError;
}
