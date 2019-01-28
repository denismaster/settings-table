workflow "PR: Build and test" {
  on = "pull_request"
  resolves = [
    "Test"
  ]
}

action "PR opened or synchronized" {
  uses = "denismaster/settings-table@master"
  args = "action 'opened|synchronize'"
}

action "Build" {
  uses = "CodeDux/dotnet/2.1@master"
  args = "build -c Release"
  needs = ["PR opened or synchronized"]
}

action "Test" {
  uses = "CodeDux/dotnet/2.1@master"
  args = "test -c Release --no-build"
  needs = ["Build"]
}
