import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/business_logic/get_main_layout/get_main_layout_bloc.dart';
import 'package:flutter_dynamic_store/providers/widgets_provider.dart';
import 'package:flutter_dynamic_store/views/dynamic_view.dart';
import 'package:flutter_dynamic_store/widgets/loading_screen.dart';

class MainView extends StatefulWidget {
  const MainView({Key? key}) : super(key: key);

  @override
  State<MainView> createState() => _MainViewState();
}

class _MainViewState extends State<MainView> {
  @override
  void initState() {
    context.read<GetMainLayoutBloc>().add(const GetMainLayout());
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: BlocBuilder<GetMainLayoutBloc, GetMainLayoutState>(
        builder: (context, state) {
          if (state is Loading) {
            return const LoadingScreen();
          }
          if (state is Success) {
            context.read<WidgetsProvider>().widgets = state.layout.widgetsMap;
            // return Column(
            //   crossAxisAlignment: CrossAxisAlignment.start,
            //   children: [
            //     const SizedBox(height: 50),
            //     Text(
            //       'Категории',
            //       style: Theme.of(context).textTheme.displayLarge,
            //       textAlign: TextAlign.left,
            //     ),
            //     Expanded(
            //       child: GridView.count(
            //         crossAxisCount: 4,
            //         children: List.generate(
            //           40,
            //           (index) => Column(
            //             children: [
            //               ClipRRect(
            //                 borderRadius: BorderRadius.circular(12),
            //                 child: Container(
            //                   color: Colors.grey,
            //                   height: 60,
            //                   width: 60,
            //                   child: Image.network(
            //                     "https://avatars.mds.yandex.net/get-marketcms/1779479/img-e8e248ef-6d42-44fb-93c8-bcb0420fbfd4.jpeg/optimize",
            //                   ),
            //                 ),
            //               ),
            //               const SizedBox(height: 10),
            //               const Text("Гитары")
            //             ],
            //           ),
            //         ),
            //       ),
            //     ),
            //   ],
            // );
            return DynamicView(state.layout);
          }
          return const SizedBox();
        },
      ),
    );
  }
}
