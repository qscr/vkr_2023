import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/models/enums.dart';
import 'package:flutter_dynamic_store/providers/data_fetcher.dart';
import 'package:flutter_dynamic_store/widgets/loading_screen.dart';
import 'package:provider/provider.dart';

class DataFetcherParser extends WidgetParser {
  @override
  Map<String, dynamic>? export(Widget? widget, BuildContext? buildContext) {
    throw UnimplementedError();
  }

  @override
  Widget parse(Map<String, dynamic> map, BuildContext buildContext, ClickListener? listener) {
    return ChangeNotifierProvider(
      create: (context) => Resolver.resolve<DataFetcher>(additionalParameters: {
        DataProviderParams.body.value: map[DataProviderParams.body.value],
        DataProviderParams.path.value: map[DataProviderParams.path.value],
        DataProviderParams.queryParams.value: map[DataProviderParams.queryParams.value],
        DataProviderParams.methodType.value:
            MethodType.fromString(map[DataProviderParams.methodType.value]),
      }),
      lazy: false,
      child: Builder(builder: (context) {
        final fetcher = context.watch<DataFetcher>();

        if (fetcher.isLoading) {
          return const LoadingScreen();
        }

        return map["child"] == null
            ? const SizedBox()
            : DynamicWidgetBuilder.buildFromMap(map["child"], context, listener) ??
                const SizedBox();
      }),
    );
  }

  @override
  String get widgetName => "DataFetcher";

  @override
  Type get widgetType => ChangeNotifierProvider<DataFetcher>;
}
