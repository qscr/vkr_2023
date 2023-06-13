import 'package:flutter_dynamic_store/helpers/app_settings.dart';

String getImageUrlById(String id) {
  const baseUrl = AppSettings.baseURL;
  return "$baseUrl/File/$id/Download";
}
