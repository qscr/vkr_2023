import 'package:flutter_dynamic_store/helpers/app_settings.dart';
import 'package:image_picker/image_picker.dart';

String getImageUrlById(String id) {
  const baseUrl = AppSettings.baseURL;
  return "$baseUrl/File/$id/Download";
}

extension XFileHelper on XFile {
  bool isValidImage() {
    if (mimeType == null) {
      return false;
    }
    final mimeTypeLower = mimeType!.toLowerCase();
    final imageTypes = [
      'png',
      'jpg',
      'jpeg',
      'image/png',
      'image/jpg',
      'image/jpeg',
    ];
    if (imageTypes.contains(mimeTypeLower)) {
      return true;
    }
    return false;
  }
}
