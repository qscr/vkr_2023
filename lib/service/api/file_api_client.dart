import 'dart:io';

import 'package:dio/dio.dart';
import 'package:flutter_dynamic_store/models/api/file/post/post_file_response.dart';
import 'package:retrofit/retrofit.dart';

part 'file_api_client.g.dart';

@RestApi()
abstract class IFileApiClient {
  factory IFileApiClient(Dio dio, {String baseUrl}) = _IFileApiClient;

  /// Отправить файл
  @POST("")
  Future<PostFileResponse> uploadFile(@Part(name: 'files') File file);
}

/// Апи-клиент приложения для File-раздела
class FileApiClient extends _IFileApiClient {
  FileApiClient(Dio dio, String baseUrl) : super(dio, baseUrl: "$baseUrl/File");
}
