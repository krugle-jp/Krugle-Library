# KrugleAI Shasta デプロイメントガイド

**バージョン**: v0.7.1-beta

- [KrugleAI Shasta デプロイメントガイド](#krugleai-shasta-デプロイメントガイド)
- [macOS](#macos)
  - [前提条件](#前提条件)
  - [インストール](#インストール)
    - [ステップ1: 設定](#ステップ1-設定)
    - [ステップ2: 初期化](#ステップ2-初期化)
    - [ステップ3: Shastaを起動](#ステップ3-shastaを起動)
  - [アンインストール](#アンインストール)
  - [アップグレード](#アップグレード)
  - [その他](#その他)
    - [ロギング](#ロギング)
    - [Shastaを停止](#shastaを停止)
- [Windows](#windows)
  - [前提条件](#前提条件-1)
  - [インストール](#インストール-1)
    - [ステップ1: 設定](#ステップ1-設定-1)
    - [ステップ2: 初期化](#ステップ2-初期化-1)
    - [ステップ3: Shastaを起動](#ステップ3-shastaを起動-1)
  - [アンインストール](#アンインストール-1)
  - [アップグレード](#アップグレード-1)
  - [その他](#その他-1)
    - [ロギング](#ロギング-1)
    - [Shastaを停止](#shastaを停止-1)
- [Linux](#linux)
  - [前提条件](#前提条件-2)
  - [インストール](#インストール-2)
    - [ステップ1: 設定](#ステップ1-設定-2)
    - [ステップ2: インストール](#ステップ2-インストール)
    - [ステップ3: Shastaを起動](#ステップ3-shastaを起動-2)
  - [アンインストール](#アンインストール-2)
  - [アップグレード](#アップグレード-2)
  - [その他](#その他-2)
    - [ロギング](#ロギング-2)
    - [Shastaを停止](#shastaを停止-2)
  - [モデルの重みを手動でダウンロードする方法](#モデルの重みを手動でダウンロードする方法)

KrugleAI Shastaは、高速かつ高パフォーマンスを実現する次世代のLLM推論サービスです。CPUとGPUリソースを自動的にバランスさせ、KrugleAI Code LLMsとのシームレスな体験を提供します。

# macOS

## 前提条件

35Bモデルの最小ハードウェア仕様

- GPU: Apple Silicon M2 Pro以上
- RAM: 64 GB
- HDD/SSD: 40 GB以上の空き容量

その他のモデルの最小ハードウェア仕様

- GPU: Apple Silicon M1以上
- RAM: 16 GB
- HDD/SSD: 10 GB以上の空き容量

プラットフォーム: darwin-arm64

## インストール

### ステップ1: 設定

Shastaをダウンロードし、パッケージをMacの任意の場所に解凍します（例: `~/Documents/shasta-darwin`）。

オプションでモデルデータアーカイブをダウンロードし、Shastaインストーラーのルートディレクトリ（例: `/Documents/shasta-darwin/.models`）に解凍して配置することができます。

`~/Documents/shasta-darwin/shasta.conf`を編集し、`YOUR_KE_API_URL`をKrugle Enterprise APIのURL（例: `https://192.168.1.100/know-api`）に置き換えてファイルを保存してください。Krugle Enterpriseサーバーで認証が有効になっている場合は、`YOUR_KE_USERNAME`と`YOUR_KE_PASSWORD`も適切に置き換えてください。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### ステップ2: 初期化

```shell
cd ~/Documents/shasta-darwin
./shasta init
```

モデルを選択するように求められます。関数呼び出しとMCPツールのサポートを備えた最新モデルである`KrugleAI Code 15B`を選択することをお勧めします。

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

このステップでは、KrugleAIモデルを取得して読み込むのに時間がかかる場合があります。`✅ KrugleAI models have been initialized`というメッセージが表示されたら、初期化が完了したことを意味します。

### ステップ3: Shastaを起動

```shell
./start.sh
```

## アンインストール

```shell
cd ~/Documents/shasta-darwin
./stop.sh
rm -rf ~/Documents/shasta-darwin
rm -rf ~/.shasta
```

## アップグレード

古いバージョンのShastaをアンインストールし、新しいバージョンをインストールしてください。

## その他

### ロギング

ログはここにあります: `$SHASTA_HOME/shasta.log`。

### Shastaを停止

```shell
cd ~/Documents/shasta-darwin
./stop.sh
```

---

# Windows

## 前提条件

35Bモデルの最小ハードウェア要件

- CPU: 12コア
- RAM: 64 GB
- HDD/SSD: 空き容量40 GB以上
- GPU（オプション）: CUDA v11+をサポートするNVIDIA GPUで、VRAMが48 GB以上。AMD GPUの場合は追加のドライバーのダウンロードとインストールが必要です。


その他のモデルの最小ハードウェア要件

- CPU: 8コア
- RAM: 16 GB
- HDD/SSD: 空き容量10 GB以上
- GPU（オプション）: CUDA v11+をサポートするNVIDIA GPUで、VRAMが8 GB以上

プラットフォーム: win-amd64 (x86-64)

Windows 11 24H2以降では、WMICがインストールされていることを確認してください。

1. **スタート > すべてのアプリ > 設定**に移動するか、**Windowsキー + I**を押して設定を開きます。
2. **システム > オプション機能**をクリックします。
3. **オプション機能の追加**の隣にある**機能の表示**を選択します。
4. 下にスクロールし、**WMIC**にチェックを入れます。
5. **次へ > 追加**をクリックして、インストールを完了します。

## インストール

### ステップ1: 設定

Shastaをダウンロードし、アーカイブの名前を`shasta-win.zip`に変更します。パッケージをWindowsの任意の場所に解凍します（例: `c:\shasta-win`）。

オプションでモデルデータアーカイブをダウンロードし、Shastaインストーラーのルートディレクトリ（例: `c:\shasta-linux\.models`）に解凍して配置することができます。

`c:\shasta-win\shasta.conf`を編集し、`YOUR_KE_HOST`をKrugle Enterpriseサーバーのホスト名に置き換え、ファイルを保存します。認証が有効な場合は、`YOUR_KE_USERNAME`と`YOUR_KE_PASSWORD`も適宜置き換えます。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### ステップ2: 初期化

```powershell
cd c:\shasta-win\
.\shasta.exe init
```

モデルを選択するように求められます。関数呼び出しとMCPツールのサポートを備えた最新モデルである`KrugleAI Code 15B`を選択することをお勧めします。

```text
Please choose an LLM to install:

A) ✨🥇 [KrugleAI Code 15B + KrugleAI Text Embedding] - SIZE: 10.15 GB RAM/VRAM: 15+ GB
B) [KrugleAI Code 10B + KrugleAI Text Embedding] - SIZE: 8.85 GB RAM/VRAM: 15+ GB
C) [KrugleAI Code 35B + KrugleAI Text Embedding] - SIZE: 23.15 GB RAM/VRAM: 48+ GB

Enter your choice: 
```

このステップでは、KrugleAIモデルを取得して読み込むのに時間がかかる場合があります。`✅ KrugleAI models have been initialized`というメッセージが表示されたら、初期化が完了したことを意味します。ネットワーク接続が表示された場合は、ShastaがKrugleAIモデルを取得するために必要です。

### ステップ3: Shastaを起動

```powershell
.\start.bat
```

## アンインストール

```powershell
cd c:\shasta-win\
.\stop.bat

del c:\shasta-win\
del c:\Users\${USER}\.shasta
```

## アップグレード

古いバージョンのShastaをアンインストールし、新しいバージョンをインストールしてください。

## その他

### ロギング

ログはここにあります: %SHASTA_HOME%\shasta.log。

### Shastaを停止

```powershell
cd c:\shasta-win\
.\stop.bat
```

---

# Linux

## 前提条件

35Bモデルの最小ハードウェア要件

- CPU: 12コア
- RAM: 64 GB
- HDD/SSD: 空き容量40 GB以上
- GPU（オプション）: CUDA v11+をサポートするNVIDIA GPUで、VRAMが48 GB以上。AMD GPUの場合は追加のドライバーのダウンロードとインストールが必要です。


その他のモデルの最小ハードウェア要件
- CPU: 8コア
- RAM: 16 GB
- HDD/SSD: 空き容量10 GB以上
- GPU（オプション）: CUDA v11+をサポートするNVIDIA GPUで、VRAMが8 GB以上; AMD GPUは追加のドライバのダウンロードとインストールが必要です。

プラットフォーム: linux-amd64

## インストール

### ステップ1: 設定

Shastaをダウンロードし、パッケージをマシンの任意の場所に解凍します（例: `/opt/shasta-linux`）。

オプションでモデルデータアーカイブをダウンロードし、Shastaインストーラーのルートディレクトリ（例: `/opt/shasta-linux/.models`）に解凍して配置することができます。

認証が有効な場合は、`/opt/shasta-linux/shasta.conf`を編集し、`YOUR_KE_USERNAME`と`YOUR_KE_PASSWORD`を適宜置き換えます。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_API_URL
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### ステップ2: インストール

> 注意: インストールスクリプトはsudo権限が必要です。ルートユーザーとして実行する必要があります。

```shell
cd /opt/shasta-linux
sudo bash ./install.sh
```

「Krugle Enterpriseサーバーホスト」を入力するように求められます。Krugle EnterpriseサーバーのIPアドレスまたはドメイン名を提供してください。

```text
Krugle Enterpriseサーバーホストを入力してください: 
```

モデルの選択を求められます。最新のモデル `KrugleAI Code 10B` を選択することをお勧めします。このモデルはパフォーマンスが向上しており、コード移行などの専門的なタスクに調整されています。

```text
Please choose an LLM to install:

A) [KrugleAI Code 7B & KrugleAI Code Base 1.5B] - SIZE: 5.8 GB RAM/VRAM: 15+ GB
B) ✨🥇 [KrugleAI Code 10B] - SIZE: 8.7 GB RAM/VRAM: 15+ GB
C) [ALL] SIZE: 14.5 GB RAM/VRAM: 15+ GB

Enter your choice: 
```

このステップでは、KrugleAIモデルを取得して読み込むのに時間がかかる場合があります。`✅ KrugleAI models have been initialized`というメッセージが表示されたら、初期化が完了したことを意味します。

### ステップ3: Shastaを起動

```shell
sudo systemctl start shasta
```

## アンインストール

```shell
cd /opt/shasta-linux
sudo bash ./uninstall.sh
sudo rm -rf /opt/shasta-linux
sudo rm -rf ~/.shasta
```

## アップグレード

古いバージョンのShastaをアンインストールし、新しいバージョンをインストールしてください。

## その他

### ロギング

ログはここにあります: /var/log/shasta/shasta.log

### Shastaを停止

```shell
sudo systemctl stop shasta
```

---

## モデルの重みを手動でダウンロードする方法

ダウンロード可能なモデル：

- KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M
- KrugleAI-Code-35B-Chat-V1.0-GGUF.Q5_K_M
- KrugleAI-text-embedding-V1.0-GGUF.Q8_0

1. Shastaインストーラーディレクトリに移動します。例：

   - **Linux**: `/root/shasta-linux`  
   - **macOS**: `~/Documents/shasta-darwin`  
   - **Windows**: `C:\shasta-win\`

2. まだインストールしていない場合は、Git LFSをインストールします：

```shell
apt-get install git-lfs
# git-lfsがインストールされていることを確認してください (https://git-lfs.com)
git lfs install
```

3. LLM重みファイル（例：KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M）をダウンロードします。

認証情報を求められたら、以下を使用してください：

- **ユーザー名**: krugleclient
- **パスワード**: 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

```shell
# $SHASTA_INSTALLER_HOME は、shasta コマンドが存在するディレクトリです

cd $SHASTA_INSTALLER_HOME
mkdir .models
cd .models
```

以下のコマンド形式でモデルをクローンしてください：`git clone $HF_MODEL_URL $krugle_MODEL_FULL_NAME`

例: [KrugleAI Code 15B + KrugleAI Text Embedding]

> 警告： フォルダ名にある`krugle_`プレフィックスに注意してください：`krugle_KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M`

```shell
git clone https://huggingface.co/krugle/KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M krugle_KrugleAI-Code-15B-Chat-V2.0-GGUF.Q5_K_M
git clone https://huggingface.co/krugle/KrugleAI-text-embedding-V1.0-GGUF.Q8_0 krugle_KrugleAI-text-embedding-V1.0-GGUF.Q8_0
```

4. モデルをロードする

以下のコマンドを実行します：

```shell
# Linuxの場合
shasta init

# macOSの場合
./shasta init

# Windowsの場合
.\shasta.exe init
```

以下のメッセージが表示されたら：

```text
Enter Y for offline installation, or any other key for online installation
```

`Y`と入力してください。

---

ライセンス

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
