cmake_minimum_required(VERSION 3.25)
project(potjedopje LANGUAGES CSharp)

file(GLOB source *.cs)

add_executable(potjedopje ${source})
set_property(TARGET potjedopje PROPERTY VS_DOTNET_REFERENCES
      "Microsoft.CSharp"
      "System"
      "System.Windows.Forms"
      "System.Drawing"
      "System.Data")

set_target_properties(potjedopje PROPERTIES RUNTIME_OUTPUT_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(potjedopje PROPERTIES RUNTIME_OUTPUT_DIRECTORY_DEBUG "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(potjedopje PROPERTIES RUNTIME_OUTPUT_DIRECTORY_RELEASE "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(potjedopje PROPERTIES RUNTIME_OUTPUT_DIRECTORY_RELWITHDEBINFO "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(potjedopje PROPERTIES VS_DEBUGGER_WORKING_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/bin")

set_property(GLOBAL PROPERTY VS_STARTUP_PROJECT potjedopje)
