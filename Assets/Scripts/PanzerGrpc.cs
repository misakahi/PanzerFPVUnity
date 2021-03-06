// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/panzer.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Panzer {
  public static partial class Panzer
  {
    static readonly string __ServiceName = "panzer.Panzer";

    static readonly grpc::Marshaller<global::Panzer.DriveRequest> __Marshaller_panzer_DriveRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.DriveRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.DriveResponse> __Marshaller_panzer_DriveResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.DriveResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.MoveTurretRequest> __Marshaller_panzer_MoveTurretRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.MoveTurretRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.MoveTurretResponse> __Marshaller_panzer_MoveTurretResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.MoveTurretResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.ControlRequest> __Marshaller_panzer_ControlRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.ControlRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.ControlResponse> __Marshaller_panzer_ControlResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.ControlResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.Ping> __Marshaller_panzer_Ping = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.Ping.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Panzer.Pong> __Marshaller_panzer_Pong = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Panzer.Pong.Parser.ParseFrom);

    static readonly grpc::Method<global::Panzer.DriveRequest, global::Panzer.DriveResponse> __Method_Drive = new grpc::Method<global::Panzer.DriveRequest, global::Panzer.DriveResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Drive",
        __Marshaller_panzer_DriveRequest,
        __Marshaller_panzer_DriveResponse);

    static readonly grpc::Method<global::Panzer.MoveTurretRequest, global::Panzer.MoveTurretResponse> __Method_MoveTurret = new grpc::Method<global::Panzer.MoveTurretRequest, global::Panzer.MoveTurretResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "MoveTurret",
        __Marshaller_panzer_MoveTurretRequest,
        __Marshaller_panzer_MoveTurretResponse);

    static readonly grpc::Method<global::Panzer.ControlRequest, global::Panzer.ControlResponse> __Method_Control = new grpc::Method<global::Panzer.ControlRequest, global::Panzer.ControlResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Control",
        __Marshaller_panzer_ControlRequest,
        __Marshaller_panzer_ControlResponse);

    static readonly grpc::Method<global::Panzer.Ping, global::Panzer.Pong> __Method_SendPing = new grpc::Method<global::Panzer.Ping, global::Panzer.Pong>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendPing",
        __Marshaller_panzer_Ping,
        __Marshaller_panzer_Pong);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Panzer.PanzerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Panzer</summary>
    [grpc::BindServiceMethod(typeof(Panzer), "BindService")]
    public abstract partial class PanzerBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Panzer.DriveResponse> Drive(global::Panzer.DriveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Panzer.MoveTurretResponse> MoveTurret(global::Panzer.MoveTurretRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Control components in bulk
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Panzer.ControlResponse> Control(global::Panzer.ControlRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Panzer.Pong> SendPing(global::Panzer.Ping request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Panzer</summary>
    public partial class PanzerClient : grpc::ClientBase<PanzerClient>
    {
      /// <summary>Creates a new client for Panzer</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PanzerClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Panzer that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PanzerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PanzerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PanzerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Panzer.DriveResponse Drive(global::Panzer.DriveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Drive(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Panzer.DriveResponse Drive(global::Panzer.DriveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Drive, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Panzer.DriveResponse> DriveAsync(global::Panzer.DriveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DriveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Panzer.DriveResponse> DriveAsync(global::Panzer.DriveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Drive, null, options, request);
      }
      public virtual global::Panzer.MoveTurretResponse MoveTurret(global::Panzer.MoveTurretRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return MoveTurret(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Panzer.MoveTurretResponse MoveTurret(global::Panzer.MoveTurretRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_MoveTurret, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Panzer.MoveTurretResponse> MoveTurretAsync(global::Panzer.MoveTurretRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return MoveTurretAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Panzer.MoveTurretResponse> MoveTurretAsync(global::Panzer.MoveTurretRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_MoveTurret, null, options, request);
      }
      /// <summary>
      /// Control components in bulk
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Panzer.ControlResponse Control(global::Panzer.ControlRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Control(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Control components in bulk
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Panzer.ControlResponse Control(global::Panzer.ControlRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Control, null, options, request);
      }
      /// <summary>
      /// Control components in bulk
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Panzer.ControlResponse> ControlAsync(global::Panzer.ControlRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ControlAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Control components in bulk
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Panzer.ControlResponse> ControlAsync(global::Panzer.ControlRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Control, null, options, request);
      }
      public virtual global::Panzer.Pong SendPing(global::Panzer.Ping request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendPing(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Panzer.Pong SendPing(global::Panzer.Ping request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendPing, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Panzer.Pong> SendPingAsync(global::Panzer.Ping request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendPingAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Panzer.Pong> SendPingAsync(global::Panzer.Ping request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendPing, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override PanzerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PanzerClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PanzerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Drive, serviceImpl.Drive)
          .AddMethod(__Method_MoveTurret, serviceImpl.MoveTurret)
          .AddMethod(__Method_Control, serviceImpl.Control)
          .AddMethod(__Method_SendPing, serviceImpl.SendPing).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PanzerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Drive, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Panzer.DriveRequest, global::Panzer.DriveResponse>(serviceImpl.Drive));
      serviceBinder.AddMethod(__Method_MoveTurret, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Panzer.MoveTurretRequest, global::Panzer.MoveTurretResponse>(serviceImpl.MoveTurret));
      serviceBinder.AddMethod(__Method_Control, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Panzer.ControlRequest, global::Panzer.ControlResponse>(serviceImpl.Control));
      serviceBinder.AddMethod(__Method_SendPing, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Panzer.Ping, global::Panzer.Pong>(serviceImpl.SendPing));
    }

  }
}
#endregion
