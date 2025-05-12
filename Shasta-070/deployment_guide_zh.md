# KrugleAI Shasta 部署手册

**Version**: v0.7.0-beta

- [KrugleAI Shasta 部署手册](#krugleai-shasta-部署手册)
- [macOS](#macos)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
    - [Step 1: Configuration](#step-1-configuration)
    - [Step 2: Initialization](#step-2-initialization)
    - [Step 3: Start Shasta](#step-3-start-shasta)
  - [Uninstallation](#uninstallation)
  - [Upgrading](#upgrading)
  - [Others](#others)
    - [Logging](#logging)
    - [Stop Shasta](#stop-shasta)
- [Windows](#windows)
  - [Prerequisites](#prerequisites-1)
  - [Installation](#installation-1)
    - [Step 1: Configuration](#step-1-configuration-1)
    - [Step 2: Initialization](#step-2-initialization-1)
    - [Step 3: Start Shasta](#step-3-start-shasta-1)
  - [Uninstallation](#uninstallation-1)
  - [Upgrading](#upgrading-1)
  - [Others](#others-1)
    - [Logging](#logging-1)
    - [Stop Shasta](#stop-shasta-1)
- [Linux](#linux)
  - [Prerequisites](#prerequisites-2)
  - [Installation](#installation-2)
    - [Step 1: Configuration](#step-1-configuration-2)
    - [Step 2: Installation](#step-2-installation)
    - [Step 2: Start Shasta](#step-2-start-shasta)
  - [Uninstallation](#uninstallation-2)
  - [Upgrading](#upgrading-2)
  - [Others](#others-2)
    - [Logging](#logging-2)
    - [Stop Shasta](#stop-shasta-2)


KrugleAI Shasta是一种新一代的LLM推理服务，专为快速运行和高性能设计。它自动平衡CPU和GPU资源，为KrugleAI Code LLMs提供流畅的使用体验

# macOS

## 前提条件

35B模型的最低硬件要求

- GPU：Apple Silicon M2 Pro+
- 内存：64 GB
- 硬盘/固态硬盘：至少40 GB可用空间

其他模型的最低硬件要求

- GPU：Apple Silicon M1+
- 内存：16 GB
- 硬盘/固态硬盘：至少10 GB可用空间

平台：darwin-arm64

## 安装

### 步骤1：配置

下载Shasta并将软件包解压到Mac上的某个位置，例如`~/Documents/shasta-darwin`。

您可以选择下载模型数据存档，解压后将其放置在Shasta安装程序的根目录中，例如`/Documents/shasta-darwin/.models`。

编辑`~/Documents/shasta-darwin/shasta.conf`，将`YOUR_KE_API_URL`替换为您的Krugle Enterprise API URL，例如`https://192.168.1.100/know-api`并保存文件。如果您的Krugle Enterprise服务器启用了身份验证，请相应地替换`YOUR_KE_USERNAME`和`YOUR_KE_PASSWORD`。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### 步骤2：初始化

```shell
cd ~/Documents/shasta-darwin
./shasta init
```

系统会要求您选择一个模型。我们建议选择最新的模型`KrugleAI Code 15B`，它提供了更好的性能，支持函数调用和MCP工具。

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

这一步可能需要一些时间来获取和加载KrugleAI模型。当您看到消息`✅ KrugleAI models have been initialized`时，表示初始化已完成。

### 步骤3：启动Shasta

```shell
./start.sh
```

## 卸载

```shell
cd ~/Documents/shasta-darwin
./stop.sh
rm -rf ~/Documents/shasta-darwin
rm -rf ~/.shasta
```

## 升级

请卸载旧版本的Shasta，然后安装新版本。

## 其他

### 日志

日志可以在此处找到：`$SHASTA_HOME/shasta.log`。

### 停止Shasta

```shell
cd ~/Documents/shasta-darwin
./stop.sh
```

---

# Windows

## 前提条件

35B模型的最低硬件要求

- CPU：12核
- 内存：64 GB
- 硬盘/固态硬盘：至少40 GB可用空间
- GPU（可选）：支持CUDA v11+的NVIDIA GPU，至少48 GB显存；AMD GPU需要额外下载并安装驱动程序。

其他模型的最低硬件要求

- CPU：8核
- 内存：16 GB
- 硬盘/固态硬盘：至少10 GB可用空间
- GPU（可选）：支持CUDA v11+的NVIDIA GPU，至少8 GB显存

平台：win-amd64 (x86-64)

重要提示：对于Windows 11 24H2及更高版本，请确保安装了WMIC。

1. 前往**开始 > 所有应用 > 设置**，或按**Windows键 + I**打开设置。
2. 点击**系统 > 可选功能**。
3. 在**添加可选功能**旁选择**查看功能**。
4. 向下滚动并勾选**WMIC**的复选框。
5. 点击**下一步 > 添加**确认并完成安装。

## 安装

### 步骤1：配置

下载Shasta并将存档重命名为`shasta-win.zip`。将软件包解压到Windows上的某个位置，例如`c:\shasta-win`。

您可以选择下载模型数据存档，解压后将其放置在Shasta安装程序的根目录中，例如`c:\shasta-linux\.models`。

编辑`c:\shasta-win\shasta.conf`，将`YOUR_KE_API_URL`替换为您的Krugle Enterprise API URL，例如`https://192.168.1.100/know-api`并保存文件。如果您的Krugle Enterprise服务器启用了身份验证，请相应地替换`YOUR_KE_USERNAME`和`YOUR_KE_PASSWORD`。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### 步骤2：初始化

```powershell
cd c:\shasta-win\
.\shasta.exe init
```

系统会要求您选择一个模型。我们建议选择最新的模型`KrugleAI Code 15B`，它提供了更好的性能，支持函数调用和MCP工具。

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

这一步可能需要一些时间来获取和加载KrugleAI模型。当您看到消息`✅ KrugleAI models have been initialized`时，表示初始化已完成。
当提示时，请允许网络连接，因为Shasta需要获取KrugleAI模型。这一步可能需要一些时间来获取和加载KrugleAI模型。当您看到消息`✅ KrugleAI models haveA been initialized`时，表示初始化已完成。

### 步骤3：启动Shasta

```powershell
.\start.bat
```

## 卸载

```powershell
cd c:\shasta-win\
.\stop.bat

del c:\shasta-win\
del c:\Users\${USER}\.shasta
```

## 升级

请卸载旧版本的Shasta，然后安装新版本。

## 其他

### 日志

%SHASTA_HOME%\shasta.log

### 停止Shasta

```powershell
cd c:\shasta-win\
.\stop.bat
```

---

# Linux

## 前提条件

35B模型的最低硬件要求

- CPU：12核
- 内存：64 GB
- 硬盘/固态硬盘：至少40 GB可用空间
- GPU（可选）：支持CUDA v11+的NVIDIA GPU，至少48 GB显存；AMD GPU需要额外下载并安装驱动程序。

其他模型的最低硬件要求

- CPU：8核
- 内存：16 GB
- 硬盘/固态硬盘：至少10 GB可用空间
- GPU（可选）：支持CUDA v11+的NVIDIA GPU，至少8 GB显存；AMD GPU需要额外下载并安装驱动程序。

平台：linux-amd64

## 安装

### 步骤1：配置

下载Shasta并将软件包解压到机器上的某个位置，例如`/opt/shasta-linux`。

您可以选择下载模型数据存档，解压后将其放置在Shasta安装程序的根目录中，例如`/opt/shasta-linux/.models`。

如果您的Krugle Enterprise服务器启用了身份验证，请编辑`/opt/shasta-linux/shasta.conf`，相应地替换`YOUR_KE_USERNAME`和`YOUR_KE_PASSWORD`。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### 步骤2：安装

> 注意：安装脚本需要sudo权限或必须以root用户身份运行。

```shell
cd /opt/shasta-linux
sudo bash ./install.sh
```

您将看到提示："输入Y进行离线安装，或输入任意其他键进行在线安装。"按任意键实时下载模型。

接下来，系统会提示您输入Krugle Enterprise API URL，例如https://KE_HOST/know-api。

然后，系统会要求您选择一个模型。我们建议选择最新的模型`KrugleAI Code 15B`，它提供了更好的性能，支持函数调用和MCP工具。

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

这一步可能需要一段时间来获取和加载KrugleAI模型。当您看到消息`✅ KrugleAI models have been initialized`时，表示初始化已完成。

### 步骤2：启动Shasta

```shell
sudo systemctl start shasta
```

## 卸载

```shell
cd /opt/shasta-linux
sudo bash ./uninstall.sh
sudo rm -rf /opt/shasta-linux
sudo rm -rf ~/.shasta
```

## 升级

请卸载旧版本的Shasta，然后安装新版本。

## 其他

### 日志

/var/log/shasta/shasta.log

### 停止Shasta

```shell
sudo systemctl stop shasta
```

---

版权信息

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
