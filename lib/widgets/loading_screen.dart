import 'package:flutter/material.dart';

class LoadingScreen extends StatelessWidget {
  const LoadingScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SizedBox(
        height: 70,
        width: 70,
        child: CircularProgressIndicator.adaptive(
          valueColor: AlwaysStoppedAnimation(Theme.of(context).primaryColor),
        ),
      ),
    );
  }
}
