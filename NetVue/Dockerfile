# 使用 asp.net core 3.1 作为基础镜像，起一个别名为 base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# 设置容器的工作目录为 /app
WORKDIR /app
# 暴露80端口
EXPOSE 80

# 使用 .net core sdk 3.1 作为基础镜像，起一个别名为 build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# 设置容器的工作目录为 /src
WORKDIR /src
# 拷贝 NetVue/NetVue.csproj 项目文件到容器中的 /src/NetVue/ 目录
COPY ["NetVue/NetVue.csproj", "NetVue/"]
# 执行 dotnet restore 命令，相当于平时用 vs 还原 nuget 包
RUN dotnet restore "NetVue/NetVue.csproj" -s "https://repo.huaweicloud.com/repository/nuget/v3/index.json"
# 拷贝当前目录的文件到到容器的 /src 目录
COPY . .
# 设置容器的工作目录为 /src/NetVue
WORKDIR "/src/NetVue"
# 执行 dotnet build 命令，相当于平时用 vs 生成项目。以 Release 模式生成到容器的 /app/build 目录
RUN dotnet build "NetVue.csproj" -c Release -o /app/build

# 将上面的 build(.net core sdk 3.1) 作为基础镜像，又重命名为 publish
FROM build AS publish
# 执行 dotnet publish 命令，相当于平时用vs发布项目。以 Release 模式发布到容器的 /app/publish 目录
RUN dotnet publish "NetVue.csproj" -c Release -o /app/publish

# 将上面的 base(asp.net core 3.1) 作为基础镜像，又重命名为 final
FROM base AS final
# 设置容器的工作目录为 /app
WORKDIR /app
# 拷贝 /app/publish 目录到当前工作目录
COPY --from=publish /app/publish .
# 指定容器入口命令，容器启动时会运行 dotnet NetVue.dll
ENTRYPOINT ["dotnet", "NetVue.dll"]
