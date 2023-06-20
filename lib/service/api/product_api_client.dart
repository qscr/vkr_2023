import 'package:dio/dio.dart';
import 'package:flutter_dynamic_store/models/api/product/delete/delete_product_request.dart';
import 'package:flutter_dynamic_store/models/api/product/get/get_shop_products_response.dart';
import 'package:flutter_dynamic_store/models/api/product/post/post_product_request.dart';
import 'package:flutter_dynamic_store/models/api/product/post/post_product_response.dart';
import 'package:retrofit/retrofit.dart';

part 'product_api_client.g.dart';

@RestApi()
abstract class IProductApiClient {
  factory IProductApiClient(Dio dio, {String baseUrl}) = _IProductApiClient;

  /// Получение всех продуктов
  @GET("")
  Future<GetShopProductsResponse> getProducts();

  /// Создание продукта
  @POST("")
  Future<PostProductResponse> createProduct(@Body() PostProductRequest request);

  /// Удаление продуктов
  @DELETE("")
  Future<void> deleteProduct(@Body() DeleteProductRequest request);
}

/// Апи-клиент приложения для Authentication-раздела
class ProductApiClient extends _IProductApiClient {
  ProductApiClient(Dio dio, String baseUrl) : super(dio, baseUrl: "$baseUrl/Product/");
}
