To get started, login to your openshift cluster

    oc login -u <USERNAME> -p <PASSWORD> --server=https://CLUSTER_API_DNS:6443

Next create the openshift project (namespace)

    oc new-project dotnet-openshift-training

Next, deploy your application to OpenShift with the "oc new-app" command.

The first parameter (-n) says what openshift project/namespace to deploy to

The second parameter (--name) says what to name the project, then takes the application type, which is dotnet:3.1, followed by a separator (~), followed by the source repo to pull for building

The third parameter (--build-env) sets an environment variable for the build (DOTNET_STARTUP_PROJECT) to the project file. This is particularly useful for projects that have multiple components, like a class library in addition to a console app or website

    oc new-app \
      -n dotnet-openshift-training \
      --name=dotnet-openshift-helloworld dotnet:3.1~https://github.com/vincent-tsugranes/dotnet-openshift-training.git \
      --build-env DOTNET_STARTUP_PROJECT=level1-helloworld/level1-helloworld.csproj
