import 'package:dynamic_widget/dynamic_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/initial/initial_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/parser_widgets/carousel_parser.dart';
import 'package:flutter_dynamic_store/parser_widgets/data_fetcher_parser.dart';
import 'package:flutter_dynamic_store/parser_widgets/dynamic_grid_parser.dart';
import 'package:flutter_dynamic_store/parser_widgets/dynamic_list_parser.dart';
import 'package:flutter_dynamic_store/parser_widgets/dynamic_picture_parser.dart';
import 'package:flutter_dynamic_store/parser_widgets/dynamic_text_parser.dart';
import 'package:flutter_dynamic_store/parser_widgets/ref_parser.dart';
import 'package:flutter_dynamic_store/providers/widgets_provider.dart';
import 'package:flutter_dynamic_store/theme/color_theme.dart';
import 'package:flutter_dynamic_store/views/initial_view.dart';
import 'package:provider/provider.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await DependencyInjection.init();
  DynamicWidgetBuilder.addParser(RefParser());
  DynamicWidgetBuilder.addParser(DataFetcherParser());
  DynamicWidgetBuilder.addParser(DynamicListParser());
  DynamicWidgetBuilder.addParser(DynamicTextParser());
  DynamicWidgetBuilder.addParser(CarouselParser());
  DynamicWidgetBuilder.addParser(DynamicGridParser());
  DynamicWidgetBuilder.addParser(DynamicPictureParser());
  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(
          create: (context) => WidgetsProvider({}),
        ),
      ],
      child: const MainApp(),
    ),
  );
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(useMaterial3: true, colorScheme: lightColorScheme),
      darkTheme: ThemeData(useMaterial3: true, colorScheme: darkColorScheme),
      debugShowCheckedModeBanner: false,
      home: BlocProvider(
        create: (context) => Resolver.resolve<InitialBloc>(),
        child: const InitialView(),
      ),
    );
  }
}
