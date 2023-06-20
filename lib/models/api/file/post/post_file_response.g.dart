// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'post_file_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$PostFileResp _$$PostFileRespFromJson(Map<String, dynamic> json) =>
    _$PostFileResp(
      PostFileFilenameToFileIdResponse.fromJson(
          json['fileNameToFileId'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$$PostFileRespToJson(_$PostFileResp instance) =>
    <String, dynamic>{
      'fileNameToFileId':
          PostFileFilenameToFileIdResponse.toJson(instance.fileNameToFileId),
    };
