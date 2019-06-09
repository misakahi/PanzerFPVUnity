#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using UnityEngine;
using System.Threading.Tasks;
using System;
using Grpc.Core;
using Panzer;

class HelloWorldTest
{
  // Can be run from commandline.
  // Example command:
  // "/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -nographics -executeMethod HelloWorldTest.RunHelloWorld -logfile"
  public static void RunHelloWorld()
  {
    Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);

    Debug.Log("==============================================================");
    Debug.Log("Starting tests");
    Debug.Log("==============================================================");

    Debug.Log("Application.platform: " + Application.platform);
    Debug.Log("Environment.OSVersion: " + Environment.OSVersion);

    // var reply = Greet("Unity");
    // Debug.Log("Greeting: " + reply.Message);

    Debug.Log("==============================================================");
    Debug.Log("Tests finished successfully.");
    Debug.Log("==============================================================");
  }

  public static Pong PingPong(string pingMsg)
  {
    // const int Port = 50051;
    const int Port = 9999;

    Channel channel = new Channel("127.0.0.1:" + Port, ChannelCredentials.Insecure);

    var client = new Panzer.Panzer.PanzerClient(channel);

    var pong = client.SendPing(new Panzer.Ping { Ping_ = pingMsg });

    channel.ShutdownAsync().Wait();

    return pong;
  }
}
