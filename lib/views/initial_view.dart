import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/get_main_layout/get_main_layout_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/initial/initial_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/items_page/items_page_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/login/login_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/web_login/web_login_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/views/login_view.dart';
import 'package:flutter_dynamic_store/views/main_view.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/web_generator_login_view.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/web_generator_view.dart';
import 'package:flutter_dynamic_store/widgets/loading_screen.dart';

class InitialView extends StatefulWidget {
  const InitialView({Key? key}) : super(key: key);

  @override
  State<InitialView> createState() => _InitialViewState();
}

class _InitialViewState extends State<InitialView> {
  @override
  void initState() {
    context.read<InitialBloc>().add(const ResolveNextRoute());
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return BlocListener<InitialBloc, InitialState>(
      listener: (context, state) {
        if (state is GoToApp) {
          Navigator.of(context).pushReplacement(
            CupertinoPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => Resolver.resolve<GetMainLayoutBloc>(),
                child: const MainView(),
              ),
            ),
          );
        }
        if (state is GoToLogin) {
          Navigator.of(context).pushReplacement(
            CupertinoPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => Resolver.resolve<LoginBloc>(),
                child: const LoginView(),
              ),
            ),
          );
        }
        if (state is GoToWebGeneratorLogin) {
          Navigator.of(context).pushReplacement(
            CupertinoPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => Resolver.resolve<WebLoginBloc>(),
                child: const WebGeneratorLoginView(),
              ),
            ),
          );
        }
        if (state is GoToWebGeneratorApp) {
          Navigator.of(context).pushReplacement(
            CupertinoPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => Resolver.resolve<ItemsPageBloc>(),
                child: const WebGeneratorView(),
              ),
            ),
          );
        }
      },
      child: const Scaffold(
        body: LoadingScreen(),
      ),
    );
  }
}
