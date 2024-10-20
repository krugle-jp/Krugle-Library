# KrugleAI Shasta デプロイメントガイド

**バージョン**: v0.6.1-beta

- [KrugleAI Shasta デプロイメントガイド](#krugleai-shasta-デプロイメントガイド)
- [macOS](#macos)
  - [前提条件](#前提条件)
    - [最小ハードウェア仕様](#最小ハードウェア仕様)
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
    - [最小ハードウェア仕様](#最小ハードウェア仕様-1)
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
    - [最小ハードウェア仕様](#最小ハードウェア仕様-2)
  - [インストール](#インストール-2)
    - [ステップ1: 設定](#ステップ1-設定-2)
    - [ステップ2: インストール](#ステップ2-インストール)
    - [ステップ3: Shastaを起動](#ステップ3-shastaを起動-2)
  - [アンインストール](#アンインストール-2)
  - [アップグレード](#アップグレード-2)
  - [その他](#その他-2)
    - [ロギング](#ロギング-2)
    - [Shastaを停止](#shastaを停止-2)

KrugleAI Shastaは、高速かつ高パフォーマンスを実現する次世代のLLM推論サービスです。CPUとGPUリソースを自動的にバランスさせ、KrugleAI Code LLMsとのシームレスな体験を提供します。

# macOS

## 前提条件

### 最小ハードウェア仕様

- CPU: 8コア
- RAM: 16 GB
- HDD/SSD: 空き容量10 GB以上
- GPU（オプション）: Apple Silicon M1+

プラットフォーム: darwin-x64, darwin-arm64

## インストール

### ステップ1: 設定

Shastaをダウンロードし、パッケージをMacの任意の場所に解凍します（例: `~/Documents/shasta-darwin`）。

`~/Documents/shasta-darwin/shasta.conf`を編集し、`YOUR_KE_HOST`をKrugle Enterpriseサーバーのホスト名に置き換え、ファイルを保存します。認証が有効な場合は、`YOUR_KE_USERNAME`と`YOUR_KE_PASSWORD`も適宜置き換えます。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_HOST
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### ステップ2: 初期化

```shell
cd ~/Documents/shasta-darwin
./shasta init
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
./start.sh
```

## アンインストール

```shell
cd ~/Documents/shasta-darwin
./stop.sh
rm -rf ~/Documents/shasta-darwin
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

### 最小ハードウェア仕様

- CPU: 8コア
- RAM: 16 GB
- HDD/SSD: 空き容量10 GB以上
- GPU（オプション）: CUDA v11+をサポートするNVIDIA GPUで、VRAMが8 GB以上

プラットフォーム: win-amd64 (x86-64)

## インストール

### ステップ1: 設定

Shastaをダウンロードし、アーカイブの名前を`shasta-win.zip`に変更します。パッケージをWindowsの任意の場所に解凍します（例: `c:\shasta-win`）。

`c:\shasta-win\shasta.conf`を編集し、`YOUR_KE_HOST`をKrugle Enterpriseサーバーのホスト名に置き換え、ファイルを保存します。認証が有効な場合は、`YOUR_KE_USERNAME`と`YOUR_KE_PASSWORD`も適宜置き換えます。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_HOST
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### ステップ2: 初期化

```powershell
cd c:\shasta-win\
.\shasta.exe init
```

モデルの選択を求められます。最新のモデル `KrugleAI Code 10B` を選択することをお勧めします。このモデルはパフォーマンスが向上しており、コード移行などの専門的なタスクに調整されています。

```text
Please choose an LLM to install:

A) [KrugleAI Code 7B & KrugleAI Code Base 1.5B] - SIZE: 5.8 GB RAM/VRAM: 15+ GB
B) ✨🥇 [KrugleAI Code 10B] - SIZE: 8.7 GB RAM/VRAM: 15+ GB
C) [ALL] SIZE: 14.5 GB RAM/VRAM: 15+ GB

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

### 最小ハードウェア仕様

- CPU: 8コア
- RAM: 16 GB
- HDD/SSD: 空き容量10 GB以上
- GPU（オプション）: CUDA v11+をサポートするNVIDIA GPUで、VRAMが8 GB以上; AMD GPUは追加のドライバのダウンロードとインストールが必要です。

プラットフォーム: linux-amd64

## インストール

### ステップ1: 設定

Shastaをダウンロードし、パッケージをマシンの任意の場所に解凍します（例: `/opt/shasta-0.6.0`）。

認証が有効な場合は、`/opt/shasta-0.6.0/shasta.conf`を編集し、`YOUR_KE_USERNAME`と`YOUR_KE_PASSWORD`を適宜置き換えます。

```text
hf_xxxxxxxxxxxxxxxxxxxxxxxxx
YOUR_KE_HOST
YOUR_KE_USERNAME
YOUR_KE_PASSWORD
```

### ステップ2: インストール

> 注意: インストールスクリプトはsudo権限が必要です。ルートユーザーとして実行する必要があります。

```shell
cd /opt/shasta-0.6.0
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
cd /opt/shasta-0.6.0
sudo bash ./uninstall.sh
sudo rm -rf /opt/shasta-0.6.0
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

ライセンス

[© 2024 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
