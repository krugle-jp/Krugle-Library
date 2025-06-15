# KrugleAI Shasta Deployment Guide

**Version**: v0.7.1-beta

- [KrugleAI Shasta Deployment Guide](#krugleai-shasta-deployment-guide)
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
  - [How to Manually Download the Model Weights](#how-to-manually-download-the-model-weights)

KrugleAI Shasta is a next-generation LLM inference service designed for rapid speed and high performance. It automatically balances CPU and GPU resources to provide a seamless experience with KrugleAI Code LLMs.

# macOS

## Prerequisites

Min Hardware Spec for the 35B Model

- GPU: Apple Silicon M2 Pro+
- RAM: 64 GB
- HDD/SSD: at least 40 GB free space

Min Hardware Spec for Other Models

- GPU: Apple Silicon M1+
- RAM: 16 GB
- HDD/SSD: at least 10 GB free space

Platform: darwin-arm64

## Installation

### Step 1: Configuration

Download Shasta and extract the package to a location on your Mac, e.g., `~/Documents/shasta-darwin`.

You can optionally download the model data archive, extract it, and place it in the Shasta installer’s root directory, e.g. `/Documents/shasta-darwin/.models`.

Edit `~/Documents/shasta-darwin/shasta.conf`, replace `YOUR_KE_API_URL` with your Krugle Enterprise API URL, e.g. `https://192.168.1.100/know-api` and save the file. If authentication is enabled on your Krugle Enterprise server, replace the `YOUR_KE_USERNAME` and `YOUR_KE_PASSWORD` accordingly.

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### Step 2: Initialization

```shell
cd ~/Documents/shasta-darwin
./shasta init
```

You will be asked to choose a model. We recommend selecting the latest model, `KrugleAI Code 15B`, which offers enhanced performance with function call and MCP tool support.

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

This step may take some time to fetch and load the KrugleAI models. When you see the message `✅ KrugleAI models have been initialized`, the initialization is complete.

### Step 3: Start Shasta

```shell
./start.sh
```
## Uninstallation

```shell
cd ~/Documents/shasta-darwin
./stop.sh
rm -rf ~/Documents/shasta-darwin
rm -rf ~/.shasta
```

## Upgrading

Please uninstall the old version of Shasta and install the new one.

## Others

### Logging

The logs can be found here: `$SHASTA_HOME/shasta.log`.

### Stop Shasta

```shell
cd ~/Documents/shasta-darwin
./stop.sh
```

---

# Windows

## Prerequisites

Min Hardware Spec for the 35B Model

- CPU: 12 cores
- RAM: 64 GB
- HDD/SSD: at least 40 GB free space
- GPU (Optional): NVIDIA GPUs with CUDA v11+ support and a minimum of 48 GB VRAM; AMD GPUs require additional driver downloads and installation.


Min Hardware Spec for Other Models

- CPU: 8 cores
- RAM: 16 GB
- HDD/SSD: at least 10 GB free space
- GPU (Optional): NVIDIA GPUs supporting CUDA v11+ with at least 8 GB VRAM

Platform: win-amd64 (x86-64)

IMPORTANT: For Windows 11 24H2 and later, ensure that WMIC is installed.

1. Go to **Start > All Apps > Settings**, or press **Windows Key + I** to open Settings.
2. Click **System > Optional Features**.
3. Select **View Features** next to **Add an optional feature**.
4. Scroll down and check the box for **WMIC**.
5. Click **Next > Add** to confirm and complete the installation.

## Installation

### Step 1: Configuration

Download Shasta and rename the archive to `shasta-win.zip`. Extract the package to a location on your Windows, e.g., `c:\shasta-win`.

You can optionally download the model data archive, extract it, and place it in the Shasta installer’s root directory, e.g. `c:\shasta-win\.models`.

Edit `c:\shasta-win\shasta.conf`,  replace `YOUR_KE_API_URL` with your Krugle Enterprise API URL, e.g. `https://192.168.1.100/know-api` and save the file. If authentication is enabled on your Krugle Enterprise server, replace the `YOUR_KE_USERNAME` and `YOUR_KE_PASSWORD` accordingly.

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### Step 2: Initialization

```powershell
cd c:\shasta-win\
.\shasta.exe init
```

You will be asked to choose a model. We recommend selecting the latest model, `KrugleAI Code 15B`, which offers enhanced performance with function call and MCP tool support.

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

This step may take some time to fetch and load the KrugleAI models. When you see the message `✅ KrugleAI models have been initialized`, the initialization is complete.
Please allow the network connection when prompted, as Shasta needs to fetch the KrugleAI models. This step may take some time to fetch and load the KrugleAI models. When you see the message `✅ KrugleAI models haveA been initialized`, the initialization is complete.

### Step 3: Start Shasta

```powershell
.\start.bat
```

## Uninstallation

```powershell
cd c:\shasta-win\
.\stop.bat

del c:\shasta-win\
del c:\Users\${USER}\.shasta
```

## Upgrading

Please uninstall the old version of Shasta and install the new one.

## Others

### Logging

%SHASTA_HOME%\shasta.log

### Stop Shasta

```powershell
cd c:\shasta-win\
.\stop.bat
```

---

# Linux

## Prerequisites

Min Hardware Spec for the 35B Model

- CPU: 12 cores
- RAM: 64 GB
- HDD/SSD: at least 40 GB free space
- GPU (Optional): NVIDIA GPUs with CUDA v11+ support and a minimum of 48 GB VRAM; AMD GPUs require additional driver downloads and installation.


Min Hardware Spec for Other Models

- CPU: 8 cores
- RAM: 16 GB
- HDD/SSD: at least 10 GB free space
- GPU (Optional): NVIDIA GPUs with CUDA v11+ support and a minimum of 8 GB VRAM; AMD GPUs require additional driver downloads and installation.


Platform: linux-amd64

## Installation

### Step 1: Configuration

Download Shasta and extract the package to a location on your machine, e.g., `/opt/shasta-linux`.

You can optionally download the model data archive, extract it, and place it in the Shasta installer’s root directory, e.g. `/opt/shasta-linux/.models`.

If authentication is enabled on your Krugle Enterprise server, edit `/opt/shasta-linux/shasta.conf`, replace the `YOUR_KE_USERNAME` and `YOUR_KE_PASSWORD` accordingly.

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### Step 2: Installation

> Note: The installation script requires sudo permission or must be run as the root user.

```shell
cd /opt/shasta-linux
sudo bash ./install.sh
```

You will be prompted with the message: "Enter Y for offline installation, or any other key for online installation." Press any key to download the model live.

Next, you will be prompted to enter your Krugle Enterprise API URL, e.g., https://KE_HOST/know-api.

Then, you will be asked to choose a model. We recommend selecting the latest model, `KrugleAI Code 15B`, which offers enhanced performance with function call and MCP tool support.

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

This step could take a while to fetch and load the KrugleAI models. When you see a message says `✅ KrugleAI models have been initialized`, that means the initialization is done.

### Step 2: Start Shasta

```shell
sudo systemctl start shasta
```
## Uninstallation

```shell
cd /opt/shasta-linux
sudo bash ./uninstall.sh
sudo rm -rf /opt/shasta-linux
sudo rm -rf ~/.shasta
```

## Upgrading

Please uninstall the old version of Shasta and install the new one.

## Others

### Logging

/var/log/shasta/shasta.log

### Stop Shasta

```shell
sudo systemctl stop shasta
```

---

## How to Manually Download the Model Weights

Available models for downloading:

- KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M
- KrugleAI-Code-35B-Chat-V1.0-GGUF.Q5_K_M
- KrugleAI-text-embedding-V1.0-GGUF.Q8_0

1. Navigate to the Shasta installer directory. Examples:

   - **Linux**: `/root/shasta-linux`  
   - **macOS**: `~/Documents/shasta-darwin`  
   - **Windows**: `C:\shasta-win\`

2. Install Git LFS if you haven't already:

```shell
apt-get install git-lfs
# Make sure git-lfs is installed (https://git-lfs.com)
git lfs install
```

3. Download the LLM weight files (e.g., KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M).

When prompted for credentials, use:

- **Username**: krugleclient
- **Password**: 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

```shell
# $SHASTA_INSTALLER_HOME is the directory where the shasta command is located.
cd $SHASTA_INSTALLER_HOME
mkdir .models
cd .models
```

Clone the model with this pattern: `git clone $HF_MODEL_URL $krugle_MODEL_FULL_NAME`.

e.g. [KrugleAI Code 15B + KrugleAI Text Embedding]

> **Warning:** Pay attention to the `krugle_` prefix in the folder name: `krugle_KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M`.

```shell
git clone https://huggingface.co/krugle/KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M krugle_KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M
git clone https://huggingface.co/krugle/KrugleAI-text-embedding-V1.0-GGUF.Q8_0 krugle_KrugleAI-text-embedding-V1.0-GGUF.Q8_0
```

4. Load the model

Run the following command:

```shell
# For Linux
shasta init

# For macOS
./shasta init

# For Windows
.\shasta.exe init
```

When prompted with:

```text
Enter Y for offline installation, or any other key for online installation
```

Type `Y`.

---

License

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
