workflow "PR: Build and test" {
  on = "pull_request"
  resolves = [
    "Test"
  ]
}

action "Build" {
  uses = "CodeDux/dotnet/2.1@master"
  args = "build -c Release"
}

action "Test" {
  uses = "CodeDux/dotnet/2.1@master"
  args = "test -c Release --no-build"
  needs = ["Build"]
}
