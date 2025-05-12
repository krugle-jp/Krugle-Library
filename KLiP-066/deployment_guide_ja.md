# KrugleAI KLiP デプロイメントガイド

**バージョン**: v0.6.6-beta

<div align="center">
<img width="500" alt="KLiP" src="logo.png">
</div>

- [KrugleAI KLiP デプロイメントガイド](#krugleai-klip-デプロイメントガイド)
  - [前提条件](#前提条件)
    - [最小ハードウェア仕様](#最小ハードウェア仕様)
    - [対応オペレーティングシステム](#対応オペレーティングシステム)
    - [ネットワーク要件](#ネットワーク要件)
  - [インストール](#インストール)
    - [KrugleAI Shastaサービス](#krugleai-shastaサービス)
    - [KrugleAI Base Proサービス（オプション）](#krugleai-base-proサービスオプション)
      - [GPUを搭載したLinuxサーバーにデプロイ](#gpuを搭載したlinuxサーバーにデプロイ)
    - [KLiP for VSCode](#klip-for-vscode)
  - [新しいバージョンへのアップグレード](#新しいバージョンへのアップグレード)

## 前提条件

### 最小ハードウェア仕様

- CPU: 8 コア
- RAM: 16 GB
- SSD/HDD: 最低 10 GB の空き容量

### 対応オペレーティングシステム

- macOS Apple Silicon
- macOS Intel
- Windows x64
- Linux x64

### ネットワーク要件

- インストールには公共ネットワークへの接続が必要です。インストール後、KLiPは公共ネットワークへのアクセスを必要としません。
- 開発用コンピュータは、KLiPの高度な機能およびライセンス登録のためにKrugle Enterpriseサーバーにアクセスできる必要があります。


## インストール

### KrugleAI Shastaサービス

[こちら](../Shasta/deployment_guide_ja.md)のガイドに従って、KrugleAI Shastaサービスをデプロイします。

### KrugleAI Base Proサービス（オプション）

> 重要: 従来のKrugleAI Base Basicは廃止され、メンテナンスされていません。代わりにKrugleAI Shastaサービスを使用してください。
>
#### GPUを搭載したLinuxサーバーにデプロイ

GPUアクセラレーションを使用したLinuxサーバーへのデプロイは、推論速度の大幅な向上とパフォーマンスの向上を提供します。[Krugle AI Baseサーバーデプロイメントガイド](https://github.com/krugle2/Krugle-AI/wiki/KrugleAI-Base-Server-Deployment-Guide)に従ってください。

### KLiP for VSCode

1. VSCode拡張マーケットプレイスで「klip」を検索してインストールします。

![](install_klip1.png)

[Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=Krugle-AI.klip)のKLiP拡張機能で「インストール」をクリックします。

![](install_klip2.png)

インストール後、左のサイドバーにKLiPのロゴが表示されます。クリックするとKLiP拡張機能が開きます。

<img width="400" alt="image" src="quick_start.png">

KLiPをVS Codeの右側のサイドバーに移動することを強くお勧めします。これにより、KLiPを使用している間もファイルエクスプローラーがアクセス可能になり、サイドバーはキーボードショートカット（cmd/ctrl + option/alt + B）で簡単に切り替えられます。

![](dnd.gif)

2. KLiPを初めてインストールして開くと、右下隅に警告メッセージが表示されます。これは、KrugleAIライセンスの設定が必要であることを意味します。

![](install_klip3.png)

KLiPの設定は自動的に開き、下記のように表示されます。Krugle EnterpriseのAPI URLを入力してください。もしKrugle Enterpriseサーバーで認証が有効になっている場合は、ユーザー名を入力してください。認証が不要な場合は、ユーザー名欄を空白のままにしてください。

![](install_klip4.png)

3. VSCode全体を再起動します。代わりに、macOSではショートカット `CMD + SHIFT + P`、他のプラットフォームでは `CTRL + SHIFT + P` を入力してウィンドウをリロードします。その後、「ウィンドウをリロード」オプションを選択します。

![](install_klip5.png)

Krugle Enterpriseサーバーで認証が有効になっている場合、エラーメッセージが表示され、「パスワードを入力してください」と求められます。この問題を解決するには、[こちらのガイド](./user_guide_ja.md#why-klip-is-not-activated)に従ってください。

次は？[👉🏻 クイックスタート](./user_guide_ja.md#quickstart)の章に従ってLLMを設定してください。

---

## 新しいバージョンへのアップグレード

1. 拡張機能から「@installed klip」を検索してKLiPをアンインストールします。

![](upgrade_klip.png)

2. VSCode拡張マーケットプレイスから「KLiP」を見つけて再インストールします。

3. 変更を適用するためにVSCodeを再起動します。

4. 「ヘルプセンター」から「KLiPセットアップウィザード」を再度実行します。

> ❗️ セットアップウィザードを実行する前に、config.sonのバックアップを取ってください。

![](upgrade_klip2.png)

[👉🏻 詳細を読む](./user_guide_ja.md#quickstart)

---

ライセンス

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
