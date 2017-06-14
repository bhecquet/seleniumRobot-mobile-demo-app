# seleniumRobot-mobile-demo-app

### Getting Started : [Official documentation](https://developer.xamarin.com/guides/cross-platform/getting_started/)
---
### For iOS development : [Official documentation](https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/)
##### Generate an IPA : [Official documentation](https://developer.xamarin.com/guides/ios/deployment,_testing,_and_metrics/app_distribution/ipa_support/#Creating_an_IPA)
It is possible that the .ipa file is not generated into the Release/Ad-Hoc file but in the Debug file.

---
### Generate an APK : [Official documentation](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/publishing_an_application/part_1_-_preparing_an_application_for_release/)
  - Go to the Project.Android properties then Android Options
  - Select 'Release' Configuration and uncheck the 'shared runtime'
  ![Alt text](/TestRoom/images//androidOption01.PNG?raw=true)
  - Go to the 'Advanced' tab and select the wanted supported architectures (In Visual Studio Community 2017 the advanced tab is a button at the bottom of the Android Option page)
  ![Alt text](/TestRoom/images//androidOption02.PNG?raw=true)
  
  - When it's done you can generate your Archive [like this](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/publishing_an_application/part_1_-_preparing_an_application_for_release/#Compile)
