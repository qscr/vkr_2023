import 'package:collection/collection.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'post_file_filename_to_file_id_response.freezed.dart';

@freezed
// ignore_for_file: invalid_annotation_target
class PostFileFilenameToFileIdResponse with _$PostFileFilenameToFileIdResponse {
  const factory PostFileFilenameToFileIdResponse(
    String? fileId,
  ) = FilenameToFileId;

  static fromJson(Map<String, dynamic> json) {
    final fileId = json.values.firstOrNull;
    return PostFileFilenameToFileIdResponse(fileId is String ? fileId : null);
  }

  static String toJson(PostFileFilenameToFileIdResponse? response) {
    return '';
  }
}
