import 'package:adaptive_navbar/adaptive_navbar.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/initial/initial_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/items_page/items_page_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/logout/logout_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/views/initial_view.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/add_items_to_store_view.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/web_generator_view.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/web_router_helper.dart';

class CustomAppBar extends AppBar {
  CustomAppBar(BuildContext context, {Key? key})
      : super(
          key: key,
          title: BlocProvider(
            create: (context) => Resolver.resolve<LogoutBloc>(),
            child: BlocConsumer<LogoutBloc, LogoutState>(
              listener: (context, state) {
                if (state is LogoutSuccess) {
                  Navigator.of(context).pushReplacement(
                    CupertinoPageRoute(
                      builder: (context) => BlocProvider(
                        create: (context) => Resolver.resolve<InitialBloc>(),
                        child: const InitialView(),
                      ),
                    ),
                  );
                }
              },
              builder: (context, state) {
                return AdaptiveNavBar(
                  screenWidth: MediaQuery.of(context).size.width,
                  title: const Row(
                    children: [
                      Text(
                        "Flutter Dynamic Store Admin Panel",
                        textAlign: TextAlign.left,
                      ),
                    ],
                  ),
                  navBarItems: [
                    NavBarItem(
                      text: "Добавить товары",
                      onTap: () {
                        if (WebNavigatorHelper.currentRoute != WebRoute.addItemsView) {
                          WebNavigatorHelper.pushWithReplacement(
                            context: context,
                            builder: (context) => BlocProvider(
                              create: (context) => Resolver.resolve<ItemsPageBloc>(),
                              child: const AddItemsToStoreView(),
                            ),
                            newWebRoute: WebRoute.addItemsView,
                          );
                        }
                      },
                    ),
                    NavBarItem(
                      text: "Генератор",
                      onTap: () {
                        if (WebNavigatorHelper.currentRoute != WebRoute.generatorView) {
                          WebNavigatorHelper.pushWithReplacement(
                            context: context,
                            builder: (context) => const WebGeneratorView(),
                            newWebRoute: WebRoute.generatorView,
                          );
                        }
                      },
                    ),
                    NavBarItem(
                      text: "Выйти",
                      onTap: () {
                        context.read<LogoutBloc>().add(const Logout());
                      },
                    ),
                  ],
                );
              },
            ),
          ),
        );
}
