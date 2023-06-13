import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/get_main_layout/get_main_layout_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/login/login_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/helpers/error_dialog.dart';
import 'package:flutter_dynamic_store/views/main_view.dart';
import 'package:flutter_dynamic_store/widgets/blobs_background.dart';
import 'package:flutter_dynamic_store/widgets/custom_input.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:text_scroll/text_scroll.dart';

class LoginView extends StatefulWidget {
  const LoginView({Key? key}) : super(key: key);

  @override
  State<LoginView> createState() => _LoginViewState();
}

class _LoginViewState extends State<LoginView> {
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
    return BlocListener<LoginBloc, LoginState>(
      listener: (context, state) {
        if (state is LoginSuccess) {
          Navigator.of(context).pushReplacement(
            CupertinoPageRoute(
              builder: (context) => BlocProvider(
                create: (context) => Resolver.resolve<GetMainLayoutBloc>(),
                child: const MainView(),
              ),
            ),
          );
        }
        if (state is LoginError) {
          showErrorDialog(context: context, message: "Произошла ошибка");
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
                        'FLUTTER DYNAMIC STORE FLUTTER DYNAMIC STORE FLUTTER DYNAMIC STORE',
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
                            BlocBuilder<LoginBloc, LoginState>(
                              builder: (context, state) {
                                return SizedBox(
                                  height: 40,
                                  width: 100,
                                  child: ElevatedButton(
                                    onPressed: () {
                                      final isValid = _formKey.currentState?.validate() ?? false;
                                      if (isValid) {
                                        context.read<LoginBloc>().add(
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
