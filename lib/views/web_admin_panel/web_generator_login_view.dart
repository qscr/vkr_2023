import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/items_page/items_page_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/web_login/web_login_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/helpers/error_dialog.dart';
import 'package:flutter_dynamic_store/views/web_admin_panel/add_items_to_store_view.dart';
import 'package:flutter_dynamic_store/widgets/blobs_background.dart';
import 'package:flutter_dynamic_store/widgets/custom_input.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:text_scroll/text_scroll.dart';

class WebGeneratorLoginView extends StatefulWidget {
  const WebGeneratorLoginView({Key? key}) : super(key: key);

  @override
  State<WebGeneratorLoginView> createState() => _WebGeneratorLoginViewState();
}

class _WebGeneratorLoginViewState extends State<WebGeneratorLoginView> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocListener<WebLoginBloc, WebLoginState>(
      listener: (context, state) {
        if (state is LoginSuccess) {
          Navigator.of(context).pushReplacement(
            CupertinoPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => Resolver.resolve<ItemsPageBloc>(),
                child: const AddItemsToStoreView(),
              ),
            ),
          );
        }
        if (state is LoginError) {
          showErrorDialog(context: context, message: state.message);
        }
      },
      child: Scaffold(
        body: SingleChildScrollView(
          child: SizedBox(
            height: MediaQuery.of(context).size.height,
            child: Stack(
              children: [
                const BlobsBackground(),
                Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Padding(
                      padding: EdgeInsets.only(bottom: 30),
                      child: TextScroll(
                        'FLUTTER DYNAMIC STORE ADMIN PANEL FLUTTER DYNAMIC STORE ADMIN PANEL',
                        mode: TextScrollMode.endless,
                        velocity: Velocity(pixelsPerSecond: Offset(30, 0)),
                        style: TextStyle(
                          fontSize: 50,
                          fontWeight: FontWeight.bold,
                          fontStyle: FontStyle.italic,
                        ),
                        selectable: false,
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 30),
                      child: Form(
                        key: _formKey,
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text("Введите email"),
                                const SizedBox(height: 10),
                                CustomInput(
                                  controller: _emailController,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(),
                                    FormBuilderValidators.email(),
                                  ]),
                                  textInputAction: TextInputAction.next,
                                ),
                              ],
                            ),
                            const SizedBox(height: 20),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text("Введите пароль:"),
                                const SizedBox(height: 10),
                                CustomInput(
                                  controller: _passwordController,
                                  obscureText: true,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(),
                                  ]),
                                  textInputAction: TextInputAction.done,
                                ),
                              ],
                            ),
                            const SizedBox(height: 30),
                            BlocBuilder<WebLoginBloc, WebLoginState>(
                              builder: (context, state) {
                                return SizedBox(
                                  height: 40,
                                  width: 100,
                                  child: ElevatedButton(
                                    onPressed: () {
                                      final isValid = _formKey.currentState?.validate() ?? false;
                                      if (isValid) {
                                        context.read<WebLoginBloc>().add(
                                              Login(
                                                email: _emailController.text,
                                                password: _passwordController.text,
                                              ),
                                            );
                                      }
                                    },
                                    child: (state is LoginLoading || state is LoginSuccess)
                                        ? const SizedBox(
                                            height: 20,
                                            width: 20,
                                            child: CircularProgressIndicator.adaptive(
                                              strokeWidth: 2,
                                            ),
                                          )
                                        : const Text("Войти"),
                                  ),
                                );
                              },
                            ),
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
