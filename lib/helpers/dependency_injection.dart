import 'package:dio/dio.dart';
import 'package:flutter_dynamic_store/business_logic/get_main_layout/get_main_layout_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/initial/initial_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/items_page/items_page_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/login/login_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/logout/logout_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/web_generator/web_generator_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/web_login/web_login_bloc.dart';
import 'package:flutter_dynamic_store/helpers/app_settings.dart';
import 'package:flutter_dynamic_store/helpers/dio_interceptors/refresh_token_interceptor.dart';
import 'package:flutter_dynamic_store/models/enums.dart';
import 'package:flutter_dynamic_store/providers/data_fetcher.dart';
import 'package:flutter_dynamic_store/service/api/authentication_api_client.dart';
import 'package:flutter_dynamic_store/service/api/file_api_client.dart';
import 'package:flutter_dynamic_store/service/api/layout_api_client.dart';
import 'package:flutter_dynamic_store/service/api/product_api_client.dart';
import 'package:flutter_simple_dependency_injection/injector.dart';

class DependencyInjection {
  static Future<void> init() async {
    final dio = Dio();
    dio.options.headers["Content-Type"] = Headers.jsonContentType;
    dio.interceptors.add(RefreshTokenInterceptor());

    const baseUrl = AppSettings.baseURL;

    final defaultInjector = Injector();

    defaultInjector.map<Dio>((injector) => dio, isSingleton: true);

    defaultInjector.map<InitialBloc>(
      (injector) => InitialBloc(
        injector.get<Dio>(),
      ),
    );

    defaultInjector.mapWithParams<DataFetcher>(
      (injector, data) => DataFetcher(
        baseUrl,
        injector.get<Dio>(),
        data[DataProviderParams.methodType.value],
        data[DataProviderParams.path.value],
        data[DataProviderParams.queryParams.value],
        data[DataProviderParams.body.value],
      ),
    );

    defaultInjector.map<AuthenticationApiClient>(
      (injector) => AuthenticationApiClient(
        dio,
        baseUrl,
      ),
    );

    defaultInjector.map<ProductApiClient>(
      (injector) => ProductApiClient(
        dio,
        baseUrl,
      ),
    );

    defaultInjector.map<LayoutApiClient>(
      (injector) => LayoutApiClient(
        dio,
        baseUrl,
      ),
    );

    defaultInjector.map<FileApiClient>(
      (injector) => FileApiClient(
        dio,
        baseUrl,
      ),
    );

    defaultInjector.map<GetMainLayoutBloc>(
      (injector) => GetMainLayoutBloc(
        injector.get<LayoutApiClient>(),
      ),
    );

    defaultInjector.map<WebGeneratorBloc>(
      (injector) => WebGeneratorBloc(
        injector.get<LayoutApiClient>(),
      ),
    );

    defaultInjector.map<LoginBloc>(
      (injector) => LoginBloc(
        injector.get<AuthenticationApiClient>(),
        injector.get<Dio>(),
      ),
    );

    defaultInjector.map<WebLoginBloc>(
      (injector) => WebLoginBloc(
        injector.get<AuthenticationApiClient>(),
        injector.get<Dio>(),
      ),
    );

    defaultInjector.map<ItemsPageBloc>(
      (injector) => ItemsPageBloc(
        injector.get<ProductApiClient>(),
        injector.get<FileApiClient>(),
      ),
    );

    defaultInjector.map<LogoutBloc>(
      (injector) => LogoutBloc(
        injector.get<Dio>(),
      ),
    );
  }
}

class Resolver {
  static T resolve<T>({String? key, Map<String, dynamic>? additionalParameters}) {
    return Injector().get<T>(key: key, additionalParameters: additionalParameters);
  }
}
