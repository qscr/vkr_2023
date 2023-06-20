const testJsonString = '''
{
  "type": "Container",
  "alignment": "center",
  "click_event" : "route://testRoute",
  "child": {
    "type": "Text",
    "data": "Dynamic Widget Testsdasd"
  }
}
''';

const testJsonRouteString = '''
{
  "initialRouteName": "MainPage",
  "widgets": [
    {
      "name": "TestSemanticElement",
      "content": {
        "type": "Text",
        "data": "InitialRoute"
      }
    },
    {
      "name": "ListOfShops",
      "content": {
        "type": "DynamicList",
        "key": "shops",
        "child": {
          "type": "Container",
          "click_event": "shop://{id}",
          "child": {
          "type": "Padding",
          "padding": "30,0,30,0",
            "child": {
              "type": "Row",
              "mainAxisAlignment": "spaceBetween",
              "children": [
                {
                  "type": "DynamicText",
                  "data": "{name}"
                },
                {
                  "type": "DynamicPicture",
                  "imageId": "{fileId}"
                }
              ]
            }
          }
        }
      }
    },
    {
      "name": "ListOfCategories",
      "content": {
        "type": "DynamicGrid",
        "key": "categories",
        "itemsCount": 3,
        "child": {
          "type": "Column",
          "children": [
            {
              "type": "DynamicPicture",
              "imageId": "{fileId}"
            },
            {
              "type": "SizedBox",
              "height": 20.0
            },
            {
              "type": "DynamicText",
              "data": "{name}"
            }
          ]
        }
      }
    }
  ],
  "routes": [
    {
      "name": "MainPage",
      "content": {
        "type": "DataFetcher",
        "path": "ShopMain/Main",
        "methodType": "get",
        "child": {
          "type": "SingleChildScrollView",
          "child": {
          "type": "Column",
            "children": [
              {
                "type": "Carousel",
                "key": "advertisements",
                "url": "{fileId}"
              },
              {
                "type": "Ref",
                "data": "ListOfCategories"
              },
              {
                "type": "Ref",
                "data": "ListOfShops"
              }
            ]
          }
        }
      }
    },
    {
      "name": "NextRoute",
      "content": {
        "type": "Container",
        "alignment": "center",
        "child": {
          "type": "Text",
          "data": "\${NextRoute}"
        }
      }
    }
  ]
}
''';
