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
  args = "test ./tests/SettingsTable.Tests/SettingsTable.Tests.csproj -c Release"
  needs = ["Build"]
}
