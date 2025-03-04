// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/auth.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace AuthService.Grpc {
  public static partial class AuthService
  {
    static readonly string __ServiceName = "auth.AuthService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AuthService.Grpc.UserSignUpRequest> __Marshaller_auth_UserSignUpRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AuthService.Grpc.UserSignUpRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AuthService.Grpc.ServiceResultReply> __Marshaller_auth_ServiceResultReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AuthService.Grpc.ServiceResultReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AuthService.Grpc.LoginRequest> __Marshaller_auth_LoginRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AuthService.Grpc.LoginRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::AuthService.Grpc.UserSignUpRequest, global::AuthService.Grpc.ServiceResultReply> __Method_CreateUserAsync = new grpc::Method<global::AuthService.Grpc.UserSignUpRequest, global::AuthService.Grpc.ServiceResultReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateUserAsync",
        __Marshaller_auth_UserSignUpRequest,
        __Marshaller_auth_ServiceResultReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::AuthService.Grpc.LoginRequest, global::AuthService.Grpc.ServiceResultReply> __Method_LoginAsync = new grpc::Method<global::AuthService.Grpc.LoginRequest, global::AuthService.Grpc.ServiceResultReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "LoginAsync",
        __Marshaller_auth_LoginRequest,
        __Marshaller_auth_ServiceResultReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::AuthService.Grpc.AuthReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AuthService</summary>
    [grpc::BindServiceMethod(typeof(AuthService), "BindService")]
    public abstract partial class AuthServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::AuthService.Grpc.ServiceResultReply> CreateUserAsync(global::AuthService.Grpc.UserSignUpRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::AuthService.Grpc.ServiceResultReply> LoginAsync(global::AuthService.Grpc.LoginRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(AuthServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateUserAsync, serviceImpl.CreateUserAsync)
          .AddMethod(__Method_LoginAsync, serviceImpl.LoginAsync).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AuthServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateUserAsync, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AuthService.Grpc.UserSignUpRequest, global::AuthService.Grpc.ServiceResultReply>(serviceImpl.CreateUserAsync));
      serviceBinder.AddMethod(__Method_LoginAsync, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AuthService.Grpc.LoginRequest, global::AuthService.Grpc.ServiceResultReply>(serviceImpl.LoginAsync));
    }

  }
}
#endregion
