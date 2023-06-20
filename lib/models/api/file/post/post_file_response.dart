import 'package:freezed_annotation/freezed_annotation.dart';
import 'post_file_filename_to_file_id_response.dart';

part 'post_file_response.g.dart';
part 'post_file_response.freezed.dart';

/// Ответ на запрос сохранения файлов
@freezed
// ignore_for_file: invalid_annotation_target
class PostFileResponse with _$PostFileResponse {
  const factory PostFileResponse(
    /// Словарь {название файла=ид сохраненного файла}
    @JsonKey(
      name: "fileNameToFileId",
      toJson: PostFileFilenameToFileIdResponse.toJson,
      fromJson: PostFileFilenameToFileIdResponse.fromJson,
    )
        PostFileFilenameToFileIdResponse? fileNameToFileId,
  ) = PostFileResp;

  factory PostFileResponse.fromJson(Map<String, dynamic> json) => _$PostFileResponseFromJson(json);
}
