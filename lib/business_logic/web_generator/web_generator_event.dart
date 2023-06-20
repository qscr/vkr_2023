part of 'web_generator_bloc.dart';

@freezed
class WebGeneratorEvent with _$WebGeneratorEvent {
  const factory WebGeneratorEvent.uploadNewLayout(Map<String, dynamic> layout) = UploadNewLayout;
}
