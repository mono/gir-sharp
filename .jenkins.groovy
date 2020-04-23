def builders = [:]
// labels to build on
def alltargets = ["ubuntu-1604-amd64","ubuntu-1604-i386"]

for (x in alltargets) {
    def mainlabel = x
    builders[mainlabel] = {
        stage("Test on ${mainlabel}") {
            ws {
                git credentialsId: '56f5f1ca-b5a7-41b5-8318-c84dd4364e72', url: 'git://github.com/mono/gir-sharp.git'
                chroot additionalPackages: 'ca-certificates-mono nuget msbuild mono-devel libgtk2.0-dev libgtk-3-dev', chrootName: "${mainlabel}-stable", command: "nuget restore Gir.sln && nuget install NUnit.ConsoleRunner -Version 3.8.0 -OutputDirectory testrunner && msbuild /p:Configuration=Release Gir.sln && mono ./testrunner/NUnit.ConsoleRunner.3.8.0/tools/nunit3-console.exe ./src/Gir.Tests/bin/Release/Gir.Tests.dll"
                step([$class: 'XUnitPublisher', testTimeMargin: '3000', thresholdMode: 1, thresholds: [[$class: 'FailedThreshold', failureNewThreshold: '5', failureThreshold: '5', unstableNewThreshold: '1', unstableThreshold: '1'], [$class: 'SkippedThreshold', failureNewThreshold: '5', failureThreshold: '5', unstableNewThreshold: '1', unstableThreshold: '1']], tools: [[$class: 'NUnit3TestType', deleteOutputFiles: true, failIfNotNew: true, pattern: '**/TestResult.xml', skipNoTestFiles: true, stopProcessingIfError: true]]])
            }
        }
    }
}

timestamps {
    node(alltargets[0]) {
        parallel builders
    }
}
