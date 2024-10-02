# KrugleAI KLiP ユーザーガイド

**バージョン**: v0.6.0-beta

<div align="center">
<img width="500" alt="KLiP" src="logo.png">
</div>

- [KrugleAI KLiP ユーザーガイド](#krugleai-klip-ユーザーガイド)
  - [はじめに](#はじめに)
  - [機能](#機能)
    - [コードを素早く簡単に理解する (Understand your code quickly and easily)](#コードを素早く簡単に理解する-understand-your-code-quickly-and-easily)
    - [スラッシュコマンドでアクションをトリガー (Trigger actions with slash commands)](#スラッシュコマンドでアクションをトリガー-trigger-actions-with-slash-commands)
    - [コンテキストにクラスやファイルを追加 (Add classes, files, and more into the context)](#コンテキストにクラスやファイルを追加-add-classes-files-and-more-into-the-context)
    - [インライン編集 (Inline Editing)](#インライン編集-inline-editing)
    - [AIによるコード自動補完 (AI-powered code autocompletion) (🚧 実験的)](#aiによるコード自動補完-ai-powered-code-autocompletion--実験的)
    - [コードベースの取得 (Codebase Retrieval)](#コードベースの取得-codebase-retrieval)
    - [ドキュメントとのチャット (Chat with your documentation) (🚧 実験的)](#ドキュメントとのチャット-chat-with-your-documentation--実験的)
    - [クイックレンズツール (Quick Lens Tools)(🚧 実験的)](#クイックレンズツール-quick-lens-tools-実験的)
      - [前提条件](#前提条件)
      - [クイックレンズツールの無効化方法](#クイックレンズツールの無効化方法)
      - [カスタムクイックレンズツール](#カスタムクイックレンズツール)
        - [使用例](#使用例)
    - [あなた自身のプロンプトをカスタマイズする (Customize Your Own Prompts) (🚧 実験的)](#あなた自身のプロンプトをカスタマイズする-customize-your-own-prompts--実験的)
      - [クイックスタート](#クイックスタート)
      - [フォーマット](#フォーマット)
        - [前文](#前文)
        - [システムメッセージ](#システムメッセージ)
        - [ビルトイン変数](#ビルトイン変数)
        - [コンテキストプロバイダー (Context Providers)](#コンテキストプロバイダー-context-providers)
    - [履歴](#履歴)
    - [モデル設定](#モデル設定)
    - [ダッシュボード (Dashboard)](#ダッシュボード-dashboard)
  - [クイックスタート (Quickstart)](#クイックスタート-quickstart)
  - [KLiPの使い方](#klipの使い方)
    - [TL;DR](#tldr)
    - [KLiPを使用するタイミング](#klipを使用するタイミング)
      - [複雑な編集の単純化](#複雑な編集の単純化)
      - [ゼロからファイルを書く](#ゼロからファイルを書く)
      - [ゼロからボイラープレートを作成](#ゼロからボイラープレートを作成)
      - [選択したコードの修正](#選択したコードの修正)
      - [選択したコードまたはファイル全体に関する質問](#選択したコードまたはファイル全体に関する質問)
      - [エラーへの対応](#エラーへの対応)
      - [適切なシェルコマンドの決定](#適切なシェルコマンドの決定)
      - [単発のオープンエンドの質問をする](#単発のオープンエンドの質問をする)
      - [小さな既存ファイルの編集](#小さな既存ファイルの編集)
      - [複数ファイルからのコンテキストの活用](#複数ファイルからのコンテキストの活用)
      - [少ないステップでタスクを実行](#少ないステップでタスクを実行)
    - [KLiPを使用しないべきタイミング](#klipを使用しないべきタイミング)
      - [詳細なデバッグ](#詳細なデバッグ)
      - [複数ファイルの並行編集](#複数ファイルの並行編集)
      - [ファイル全体のコンテキストを使用する場合](#ファイル全体のコンテキストを使用する場合)
      - [大きなファイルの編集](#大きなファイルの編集)
      - [非常に長い行を選択する場合](#非常に長い行を選択する場合)
      - [多くのステップを伴うタスク](#多くのステップを伴うタスク)
  - [設定 (Configuration)](#設定-configuration)
    - [LLMの設定](#llmの設定)
    - [LLMパラメータの調整](#llmパラメータの調整)
    - [AI搭載のコード自動補完 (AI-powered code autocompletion)](#ai搭載のコード自動補完-ai-powered-code-autocompletion)
      - [`tabAutocompleteModel`](#tabautocompletemodel)
      - [`tabAutocompleteOptions`](#tabautocompleteoptions)
      - [例](#例)
      - [コードオートコンプリートのトグル](#コードオートコンプリートのトグル)
    - [コンテキストプロバイダー (Context Providers)](#コンテキストプロバイダー-context-providers-1)
      - [ビルトインコンテキストプロバイダー](#ビルトインコンテキストプロバイダー)
        - [ファイル](#ファイル)
        - [開いているファイル](#開いているファイル)
        - [コード](#コード)
        - [Git Diff](#git-diff)
        - [コードベースの取得](#コードベースの取得)
        - [フォルダ](#フォルダ)
        - [ワークスペース内の正確な検索（RegExpパターン）](#ワークスペース内の正確な検索regexpパターン)
        - [ファイルツリー](#ファイルツリー)
        - [URL](#url)
        - [ドキュメント](#ドキュメント)
        - [ターミナル (Terminal)](#ターミナル-terminal)
        - [GitHubの課題 (GitHub Issues)](#githubの課題-github-issues)
        - [GitLab マージリクエスト (GitLab Merge Request)](#gitlab-マージリクエスト-gitlab-merge-request)
        - [Jira 課題 (Jira Issues)](#jira-課題-jira-issues)
        - [オペレーティングシステム](#オペレーティングシステム)
        - [Krugle Enterpriseファイル - 作業中、近日公開](#krugle-enterpriseファイル---作業中近日公開)
        - [PostgreSQL - 作業中、近日公開](#postgresql---作業中近日公開)
        - [データベーステーブル - 作業中、近日公開](#データベーステーブル---作業中近日公開)
        - [デバッガー：ローカル変数 - 作業中、近日公開](#デバッガーローカル変数---作業中近日公開)
        - [コンテキストプロバイダーのリクエスト](#コンテキストプロバイダーのリクエスト)
    - [スラッシュコマンド (Slash Commands)](#スラッシュコマンド-slash-commands)
      - [組み込みスラッシュコマンド](#組み込みスラッシュコマンド)
        - [/edit](#edit)
        - [/comment](#comment)
        - [/share](#share)
        - [/cmd](#cmd)
        - [/commit](#commit)
      - [カスタムコマンドの自然言語使用 (非推奨)](#カスタムコマンドの自然言語使用-非推奨)
  - [FAQ](#faq)
    - [KLiPが有効化されない理由](#klipが有効化されない理由)
      - [無効な資格情報](#無効な資格情報)
    - [KLiPが文字化けしたテキストを出力し続ける理由](#klipが文字化けしたテキストを出力し続ける理由)
    - [どのファイルをインデックスから除外するかをカスタマイズするには？](#どのファイルをインデックスから除外するかをカスタマイズするには)
    - [なぜShastaはすべてのCPUコアを使用していないのか？](#なぜshastaはすべてのcpuコアを使用していないのか)
    - [コード補完が表示されない](#コード補完が表示されない)
    - [補完が遅い](#補完が遅い)
    - [補完が私のコードを認識しない](#補完が私のコードを認識しない)
    - [補完にフォーマットエラーが含まれている](#補完にフォーマットエラーが含まれている)
    - [Quick Lensツールが表示されないのはなぜですか？](#quick-lensツールが表示されないのはなぜですか)

## はじめに

KLiPは、ソフトウェア開発のために設計されたエンタープライズコードオートパイロットツールで、KrugleAIの機能をIDEに統合しています。

KLiPを使用すると、ワークフローをナビゲートしながら、生成された回答をシームレスにコードベースに取り入れることができ、KrugleAIの強力なコード言語モデル（LLM）を直接IDE内で活用できます。

実現可能な例としては以下のようなものがあります：

- `cmd/ctrl + I`を利用して、自然言語からボイラープレートコードを生成する。
- コードを選択し、リファクタリング手順を説明すると、エディタ内で即座に変更が適用される。
- コードベースに関する高レベルの質問を投げかけ、KLiPが自動的に関連ファイルを特定する（アルファ版）。
- 任意の関数やクラスに対して効率的にユニットテストを生成する。
- エディタを離れずに即座に回答を得るための簡単な質問をする。
- コンパイラの範囲を超えるエラーのために、現在の変更をレビューしてもらう。
- LLMとのコミュニケーション中にさまざまなソースを参照するために、単に ***@*** と入力するだけです。コード言語やフレームワークのドキュメント用の `@docs`、Krugleエンタープライズプラットフォームによってインデックスされたファイルやドキュメントのための `@krugle`、Jiraの問題を参照するための `@jira` など、追加のコンテキストプロバイダーが今後提供される予定です。
- 拡張機能を特定のワークフローに合わせてカスタマイズするための広範な設定オプションを提供しています。
- インライン提案と迅速なボイラープレートコード作成のために、ローカルタブオートコンプリートを活用します（アルファ版）。

## 機能

### コードを素早く簡単に理解する (Understand your code quickly and easily)

![](code_explanation.gif)

コードに困ったとき、KLiPがそれを分解し、デバッグと理解を迅速化するための明確で簡潔な説明を提供します。

`cmd + L`（Mac）または`ctrl + L`（Windows）を押して、作業中のコードについての洞察を得てください。

### スラッシュコマンドでアクションをトリガー (Trigger actions with slash commands)

![](slash_commands.gif)

KLiPのスラッシュコマンドを使うと、コーディング環境を離れずに迅速かつ効率的にアクションを実行できます。

### コンテキストにクラスやファイルを追加 (Add classes, files, and more into the context)

![](add_context.gif)

チャットボックスにコンテキストをコピー＆ペーストすると、ワークフローが中断されることがあります。KLiPでは、現在のコンテキストにクラスやファイルなどを追加できるので、必要なものに一か所でアクセスできます。また、LLMの知識のカットオフの問題にも対処します。

### インライン編集 (Inline Editing)

作業中のコードを直接リファクタリングします。

![](inline_edit_01.gif)

選択したコードに対して使用できるインライン編集ツールが組み込まれています。

![](inline_edit_02.gif)

### AIによるコード自動補完 (AI-powered code autocompletion) (🚧 実験的)

KLiPは、AIによるコード自動補完をサポートしています。Tabキーを押すだけで簡単にコードの提案を得ることができます。

![](ai_code_autocomplete.gif)

![](ai_code_autocomplete_02.gif)

### コードベースの取得 (Codebase Retrieval)

コードベースに関する質問をしてください。

![](codebase_retrieval.gif)

KLiPはあなたのコードベースをインデックス化し、ワークスペース全体から最も関連性の高いコンテキストを自動的に引き出すことを可能にします。これは、エンベディングベースの取得とキーワード検索の組み合わせによって実現されます。デフォルトでは、すべてのエンベディングが計算され、ローカルに保存されます。

コードベースの取得機能は、現在「コードベース」と「フォルダー」のコンテキストプロバイダーを通じて利用可能です。入力ボックスに`@codebase`または`@folder`と入力し、質問をすることで使用できます。入力はコードベース（またはフォルダー）の他の部分からのエンベディングと比較され、関連するファイルを特定します。

**一般的な使用例:**

- **コードベースに関する高レベルの質問**
  - "Springセキュリティ機能はどこで使用されていますか？"
  - "サーバーに新しいエンドポイントを追加するにはどうすればよいですか？"
  - "XMLをJSONに変換する既存のコードはありますか？"

- **既存のサンプルを参考にしてコードを生成する**
  - "他の`xyz`のサブクラスで見られるパターンに従って、`foo`クラスに`bar`メソッドを実装してください。"
  - "Pythonのargparseを使用して、このプロジェクトのCLIアプリケーションのドラフトを作成してください。"
  - "既存のコンポーネントと同じパターンを使用して、ドロップダウンリストを持つ新しいVue.jsコンポーネントを生成してください。"

- **特定のフォルダーのクエリには`@folder`を使用**
  - "このフォルダーの主な目的は何ですか？"
  - "Krugleのファイル検索APIをどのように使用しますか？"
  - 上記の例のいずれかを`@folder`を使用して。

**役に立たない場合:**

- **LLMがコードベース内のすべてのファイルにアクセスする必要がある場合** - KrugleAI Webの使用を検討してください。
  - "`foo`関数が呼び出されているすべての場所を見つけてください。"
  - "コードベースをレビューし、スペルミスを見つけてください。"

- **リファクタリング**
  - "`bar`関数に新しいパラメータを追加し、その使用箇所を更新してください。"

### ドキュメントとのチャット (Chat with your documentation) (🚧 実験的)

`@docs`コンテキストプロバイダーを使用すると、KLiP内で直接ドキュメントと対話できます。この機能により、任意の静的サイトやGitHubのマークダウンページをインデックス化し、コーディング中にドキュメントに簡単にアクセスして活用できるようになります。

![](docs.gif)

`@docs`コンテキストプロバイダーは、指定されたドキュメントサイトをクロールしてエンベディングを生成し、それをローカルに保存します。このプロセスにより、ドキュメントコンテンツに迅速かつ効率的にアクセスできます。

人気のあるフレームワークやライブラリのために、事前にインデックス化されたドキュメントサイトの選択肢も提供しています。これらは`@docs`コンテキストプロバイダーのドロップダウンリストから見つけることができます。

独自のドキュメントを追加するには、[こちら](#documentation)をご覧ください。

![](docs_add.gif)

### クイックレンズツール (Quick Lens Tools)(🚧 実験的)

クイックレンズツールは、クラスや関数全体を迅速に選択して編集できるようにし、開発ワークフローを効率化します。カスタムクイックレンズツールを設定して、1回のクリックで複雑な操作を実行できます。

![](quick_lens_actions.gif)

#### 前提条件

> 開いているファイルの言語に対して[Language Server Protocol](https://microsoft.github.io/language-server-protocol/)拡張機能がインストールされている必要があります。VSCodeが言語のLanguage Server Protocolをサポートしていない場合は、VSCode拡張機能マーケットプレイスで「Language Server Protocol」を検索してください。

例えば、KLiP Quick LensをJavaで使用したい場合、VSCodeのJava言語を有効にしていない場合は、「Javaの拡張パック」を検索してインストールすることでLanguage Server Protocolを含めることができます。

![](quick_lens_actions_prereq.png)

#### クイックレンズツールの無効化方法

クイックレンズツールはデフォルトで有効になっています。無効にするには、設定メニュー（`cmd/ctrl + ,`）を開き、「`klip.enableQuickLensTools`」を検索し、チェックボックスをオフにしてください。

#### カスタムクイックレンズツール

カスタムクイックレンズツールを使用すると、デフォルトのアクションを超えて機能を特定のニーズに合わせて調整できます。これらのカスタムアクションは、`~/.klip/config.json`ファイルで簡単に設定できます。

##### 使用例

1. **コード移行 (Code Migration)**
   クラスや関数を別の言語に変換するツールです。例えば、任意のコードをJavaに変換します。

```json
   "experimental": {
      "quickActions": [
         {
            "title": "To Java",
            "prompt": "Translate this code into the target language, ensuring that it adheres to the syntax rules of the target language and guarantees functional correctness. Target language: Java.",
            "sendToChat": true
         }
      ]
   }
```

2. **インラインドックストリングの生成 (Generate Inline Docstring)**
   クラスや関数のためのドックストリングを生成して挿入するツールです。

```json
   "experimental": {
      "quickActions": [
         {
            "title": "Docstring",
            "prompt": "Write a Docstring for this Code. Do not change anything about the code itself."
         }
      ]
   }
```

3. **インラインユニットテストの作成 (Write an Inline Unit Test)**
   選択したコードの上にユニットテストを生成して挿入するツールです。

   ```json
   "experimental": {
      "quickActions": [
         {
            "title": "Unit test",
            "prompt": "Write a unit test for this code. Do not change anything about the code itself."
         }
      ]
   }
   ```

4. **詳細な説明のためにコードをチャットパネルに送信 (Send Code to Chat Panel for Detailed Explanation)**  
   デフォルトの「説明」機能はコードの簡単な概要を提供します。このクイックアクションは、コードとプロンプトをチャットに送信し、より詳細な説明を得るためのものです。

   ```json
   "experimental": {
      "quickActions": [
         {
            "title": "Detailed explanation",
            "prompt": "Provide an in-depth explanation of the following code, covering all methods and properties.",
            "sendToChat": true
         }
      ]
   }
   ```

5. **TypeScriptインターフェースの作成 (Create a TypeScript Interface)**  
    選択したコードの上にTypeScriptインターフェースを生成して挿入するクイックアクションです。

   ```json
   "experimental": {
      "quickActions": [
         {
            "title": "Create Interface",
            "prompt": "Create a new TypeScript interface for the following code."
         }
      ]
   }
   ```

### あなた自身のプロンプトをカスタマイズする (Customize Your Own Prompts) (🚧 実験的)

カスタマイズしたプロンプトファイルを作成することで、共通のパターンを標準化し、チームとLLMプロンプトを共有できます。これらのファイルは、プロンプトの作成と使用を簡素化します。

![](prompt_customization.gif)

#### クイックスタート

Jestを使用してユニットテストを書くためのプロンプトファイルのセットアップの簡単な例を示します。

1. ワークスペースの最上位に「.prompts/」という名前のフォルダーを作成します。
2. このフォルダーに「ut.prompt」というファイルを追加します。このファイル名は、プロンプトを生成するために使用するスラッシュコマンドの名前になります。
3. `ut.prompt`に以下の内容を書き込み、保存します：

```text
temperature: 0.5
maxTokens: 4096
---
<system>
You are an expert programmer
</system>

{{{ input }}}

Write unit tests for the above selected code, following these instructions:
- Use `jest`
- Properly set up and tear down
- Include important edge cases
- Make the tests comprehensive and sophisticated
- Provide the tests as chat output without editing any files
- Don't explain how to set up `jest`
```

このプロンプトを使用するには、ファイルビューからコードを選択し、KLiPサイドバーで`cmd/ctrl + L`を使用して選択します。次に、"/"を入力してスラッシュコマンドのリストを表示し、「ut」を選択します（これは新しいスラッシュコマンドです）。エンターキーを押すと、LLMがプロンプトファイルに基づいて応答を生成します。

#### フォーマット

> このフォーマットは実験的であり、変更される可能性があります。

##### 前文

「前文」は`---`区切りの上にあるすべての内容で、モデルのパラメーターを指定できます。YAML構文を使用し、現在次のパラメーターをサポートしています：

- `name`
- `temperature`
- `topP`
- `topK`
- `minP`
- `presencePenalty`
- `frequencyPenalty`
- `mirostat`
- `stop`
- `maxTokens`
- `description`

これらのパラメータが不要な場合、前置きと`---`区切りを省略できます。

##### システムメッセージ

システムメッセージを追加するには、本文を`<system></system>`タグで始め、システムメッセージをその中に配置します。

##### ビルトイン変数

以下のビルトイン変数が利用可能です：

- `{{{ input }}}` - サイドバーの入力ボックスからスラッシュコマンドと共に送信された全文
- `{{{ currentFile }}}` - IDEで現在開いているファイル
- `{{{ ./path/to/file.js }}}` - 任意のファイルを直接参照できます

##### コンテキストプロバイダー (Context Providers)

`config.json`に追加されたKLiPのコンテキストプロバイダーは、その名前で参照できます。入力を受け付けるコンテキストプロバイダーにも対応しています。

- `{{{ terminal }}}` - ターミナルの内容
- `{{{ url "https://foobar.com" }}}` - URLの内容

### 履歴

履歴ページでチャット履歴を開き、チャットのタイトルを編集したり、チャットを削除したりできます。

<img width="400" alt="履歴" src="history.gif">

### モデル設定

リモートサーバーから別のKrugleAI 10Bモデルを追加するなどの特定のニーズがある場合は、チャットボックスからモデルを選択し、KrugleAI Shastaプロバイダーから新しい10Bモデルを追加できます。設定を変更するには、右下のギアアイコンをクリックして`config.json`ファイルを編集します。

![](model_setup01.png)

KLiPはOpenAIモデルおよびOpenAI APIプロトコルと互換性のある任意のモデルもサポートしています。APIキーを追加し、詳細設定でAPIベースURLを指定するだけで利用できます。

![](model_setup02.png)

### ダッシュボード (Dashboard)

ダッシュボードでは、インデックス状況やトークン使用状況などを確認できます。

![](dashboard.png)

---

## クイックスタート (Quickstart)

1. [こちら](../Shasta/deployment_guide_ja.md)のデプロイメントガイドに従ってShastaをインストールし、[こちら](./deployment_guide_ja.md)でKLiPをインストールします。

2. インストールが完了すると、左のサイドバーにKLiPのロゴが表示されます。それをクリックすると、KLiP拡張機能が開きます。

<img width="400" alt="quick_start" src="quick_start.png">

KLiPをVS Codeの右サイドバーに移動することを強くお勧めします。これにより、KLiPを使用しながらファイルエクスプローラーに簡単にアクセスでき、サイドバーはキーボードショートカット（`cmd/ctrl + option/alt + B`）で簡単に切り替えられます。

![](dnd.gif)

3. KLiPのセットアップウィザードに従ってモデルを設定します。

<img width="400" alt="Setup Wizard" src="setup_wizard.gif">

4. これでインターネットから切断し、KLiPを使用してAIコード開発の力を活用できます。

---

## KLiPの使い方

### TL;DR

LLM（大規模言語モデル）をコーディングプロセスに取り入れることで、適切に使用すれば効率が向上します。このガイドでは、KLiPを利用するのに適したシナリオと、使用を控えるべき状況について説明します。

KLiPの効果は、編集や説明を生成するために使用されるKrugleAIのコードLLMに依存します。LLMは時に存在しないライブラリや構文を提案するなど、不正確な提案を生成することがあります。そのため、正しくない提案に遭遇した場合は、関連するドキュメントと照らし合わせることをお勧めします。

KLiPを使用することで、KLiPの提案を信頼するタイミングを見極められるようになります。KLiPに慣れる良いアプローチは、実験を通じて望ましい結果を得るための洞察を得ることです。KLiPは提案された変更を受け入れるか拒否するかを促し、必要に応じて変更を元に戻す柔軟性を提供します。

特定のタスクに対するKLiPの支援の可能性に不安がある場合、次のステップを考慮してください。

「選択」とは、ファイル内のテキスト範囲を選択し、`cmd + L`（macOS）または`ctrl + L`（Windows）を押してKLiPチャットメッセージに含めることを指します。

- **選択**: より良く理解したいコードセクションを選択し、入力ボックスに「このコードの仕組みを教えてください」と入力します。
- **評価**: 説明が妥当に思える場合、選択したコードセクションのままで「このコードを[INSERT TASK]に変更するにはどうしますか？」と尋ねます。
- **修正**: 説明が期待に応えるものであれば、選択したコードセクションのままで`/edit [INSERT TASK]`を入力します。提案された変更に満足した場合は、`cmd/crtl + shift + enter`を使用して実施します。
- **反復的アプローチ**: 最初の試みが望ましい結果を生まない場合は、`cmd/ctrl + shift + backspace`を使用して変更を拒否し、再試行します。KLiPは毎回異なる提案を行うことがあります。
- **明確化**: KLiPが期待した結果を出さない場合、より具体的な指示を提供し、期待をはっきりと伝えます。
- **分解**: すべてがうまくいかない場合は、タスクを小さなサブタスクに分解し、コードLLMまたは手動でそれらを個別に処理することを検討します。

コードに対する責任はすべてあなたにあり、あなた自身が作成したものであろうとLLMによって生成されたものであろうと関係ありません。したがって、LLMが生成した出力を確認することが重要です。このプロセスを容易にするために、KLiPのGUIはLLMが実行したアクションの自然言語による説明を提供します。

### KLiPを使用するタイミング

KLiPは、タスクを効率的に完了するために役立つさまざまなシナリオで非常に有用です。

#### 複雑な編集の単純化

KLiPは、従来の検索と置換方法が不十分な場合、特に効果的です。たとえば、「/edit これらすべてをああするように変更」といったコマンドを実行する場合です。

**例**

- "/edit Replace the vertical bar with 'Union' at this location"
- "/edit Enhance readability by using more descriptive variable names here"

#### ゼロからファイルを書く

KLiPは、Reactコンポーネント、Pythonスクリプト、シェルスクリプト、Makefile、単体テストなど、さまざまなファイルタイプを開始するプロセスを簡略化します。

**例**

- "/edit Draft a Python script to retrieve the latest news from The New York Times"
- "/edit Integrate a React component for syntax-highlighted code"

#### ゼロからボイラープレートを作成

KLiPは、ボイラープレート構造を作成するのを助けることにより、その能力をさらに拡張します。たとえば、引数をソートして表示するtyper CLIアプリを備えたPythonパッケージのフレームワークを構築するのに役立ちます。

**例**

- "/edit Utilize this schema to generate a SQL query that retrieves recently churned users"
- "/edit Develop a shell script to back up my home directory to /tmp/"

#### 選択したコードの修正

コードのセクションを選択した後、それをKLiPを使用して改善することを目指します（例："/edit このように動作するように関数を修正する"または"/edit これを普遍的に実装する"）。

**例**

- "/edit adapt this digital ocean Terraform file to function with GCP"
- "/edit rewrite this function to be async"

#### 選択したコードまたはファイル全体に関する質問

特定のコードの動作が不明な場合、それを選択して「このコードはどう機能しますか？」と尋ねます。

**例**

- "where within the page should I make this request to the backend?"
- "how can I facilitate communication between these iframes?"

#### エラーへの対応

KLiPはエラーや例外を明確にし、潜在的な解決策を提案するのに役立ちます。ターミナルでエラーや例外に遭遇した場合は、`cmd + shift + R`（macOS）または`ctrl + shift + R`（Windows）を押します。この操作により、スタックトレースがKLiPに送信され、問題の説明が促されます。

#### 適切なシェルコマンドの決定

焦点を移し、気を散らされることなく、「ポート8000で実行中のプロセスを特定するにはどうすればよいですか？」と尋ねることができます。

**例**

- "what is the name of the load_dotenv library?"
- "how do I identify running processes on port 8000?"

#### 単発のオープンエンドの質問をする

IDEを離れることなく、マルチターンの会話に発展することを期待しないオープンエンドの質問をすることができます。

**例**

- "how can I set up a Prisma schema to cascade deletes?"
- "what is the difference between dense and sparse embeddings?"

#### 小さな既存ファイルの編集

ファイルが大きすぎなければ、KLiPに全体のファイルを選択して強化を依頼できます。

**例**

- "/edit here's a connector for PostgreSQL, now create one for Kafka"
- "/edit Revise this API call to retrieve all pages"

#### 複数ファイルからのコンテキストの活用

手動での修正と同様に、1つのファイルに集中します。ただし、他のファイルに関連情報が含まれている場合は、それらのコードセグメントも選択して追加のコンテキストとして使用します。

#### 少ないステップでタスクを実行

KLiPは、通常、完了するのにあまり手順を要しないタスクを支援できます。

**例**

- "/edit generate an IAM policy for creating a user with read-only access to S3"
- "/edit transform this plot into a bar chart within this dashboard component"

### KLiPを使用しないべきタイミング

以下は、現時点でKLiPが**役に立たない**シナリオです。

#### 詳細なデバッグ

複数のファイルにわたる複雑な問題を約20分間デバッグしている場合、KLiPはすべての点を結びつけるのに役立たないかもしれません。ただし、進捗を共有し提案を求めることで、KLiPが潜在的な解決策のアイデアを提供してくれることがあります。

#### 複数ファイルの並行編集

現在、KLiPは一度に1つのファイルの編集しか処理できません。しかし、必要な変更を特定した後は、KLiPに逐次的に複数ファイルの修正を手助けさせることができます。

#### ファイル全体のコンテキストを使用する場合

非常に大きなファイルの場合、KLiPは限られたLLMコンテキストウィンドウのため、全体の内容を取り込むのが難しいことがあります。関連するコンテキストを含む特定のコードセクションを選択することを検討してください。完全なファイルはほとんど必要ありません。

#### 大きなファイルの編集

同様に、あまりにも多くの行を一度に編集しようとすると、コンテキストウィンドウの制限を超えてしまい、提案を適用する際にパフォーマンスが低下することがあります。

#### 非常に長い行を選択する場合

非常に長い行（例：複雑なSVG）を選択すると、上記の問題と同様の課題が発生する可能性があります。

#### 多くのステップを伴うタスク

KLiPは一度にタスクを包括的に処理することはできませんが、タスクをサブタスクに分解することで、各ステップに対してKLiPが支援を提供できることがよくあります。

---

## 設定 (Configuration)

KLiPの右下にある歯車アイコンをクリックすると、手動でconfig.jsonファイルを構築できます。

<img width="486" alt="image" src="config.png">

### LLMの設定

config.jsonファイル内で、「models」プロパティを見つけます。このプロパティには、KLiPで使用するために保存されたモデルのリストが含まれています。

```json
"models": [
    {
      "title": "KrugleAI Code 10B",
      "provider": "krugle-shasta",
      "model": "krugle-code-10b",
      "apiBase": "http://127.0.0.1:5668",
      "contextLength": 16384,
      "completionOptions": {
        "temperature": 0.7,
        "topK": 45,
        "topP": 0.75,
        "maxTokens": 4096
      },
      "template": "krugle-10b-en"
    }
]
```

モデルのプロパティを指定するだけで、KLiPはプロンプトテンプレートやその他の関連情報を自動的に検出します。

ただし、KrugleAI Base Proサービスを利用している場合は、config.jsonファイルをカスタマイズする前に、KrugleAI Base Proに必要な変更を加えていることを確認してください。

```json
"models": [
    {
      "title": "KrugleAI Code 7B Pro",
      "provider": "krugle",
      "model": "krugle-7b",
      "apiKey": "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",
      "apiBase": "http://127.0.0.1:5666/v1",
      "contextLength": 16384,
      "completionOptions": {
        "temperature": 0.7,
        "topK": 45,
        "topP": 0.75,
        "maxTokens": 2048
      },
      "template": "krugle-jp"
    },
]
```

例:

- （オプション）KAI_FLAGS.txt内のLLMを`%KRUGLE_AI_BASE_HOME`から切り替えます。
- （オプション）KAI_FLAGS.txt内のAPIキーを`%KRUGLE_AI_BASE_HOME`から変更します。

### LLMパラメータの調整

LLMの出力におけるランダム性と創造性を管理するために、LLMのパラメータを変更できます。

利用可能なパラメータは`temperature`、`topK`、`topP`、`maxTokens`です。これらのパラメータは、KrugleAIモデルを含むGPT（Generative Pre-trained Transformer）モデルで一般的に使用され、生成されるテキストの挙動と品質を制御します。

例:

```json
"models": [
    {
      "title": "KrugleAI Code 10B",
      "provider": "krugle-shasta",
      "model": "krugle-code-10b",
      "apiBase": "http://127.0.0.1:5668",
      "contextLength": 16384,
      "completionOptions": {
        "temperature": 0.5,
        "topK": 45,
        "topP": 0.75,
        "maxTokens": 4096
      },
      "template": "krugle-10b-en"
    }
]
```

以下は各項目の簡潔で明確な説明です：

1. **Temperature**: このパラメータは生成されるテキストのランダム性を制御します。温度値が低いほどモデルは保守的かつ決定論的になり、予測可能な出力が得られます。一方、温度値が高いほどランダム性が増し、多様性のある出力が得られますが、整合性が欠ける可能性があります。上記の例では、温度は1に設定されており、中立的な設定です。

2. **Top-k**: このパラメータは生成プロセスの各ステップで考慮されるトークンの数を制限します。モデルは確率分布に基づいて最も可能性の高いk個のトークンのみを考慮します。これにより、モデルが非現実的または意味不明なトークンを生成するのを防ぎます。上記の例では、topKは45に設定されており、各ステップで最も高い確率を持つトップ45のトークンのみが考慮されます。

3. **Top-p（ヌクレウスサンプリング）**: ヌクレウスサンプリングとも呼ばれ、このパラメータは累積確率質量に基づいて考慮されるトークンの数を動的に調整します。これにより、生成されたトークンの累積確率質量が特定の閾値（topPで指定）を超えるようにしつつ、多様な出力を生成できます。上記の例では、topPは0.75に設定されており、累積確率質量が75%を超えるまでトークンが考慮されます。

4. **Max tokens**: このパラメータは、モデルが単一の推論リクエストで生成できる最大トークン数を設定します。生成されるテキストの長さを制御し、モデルが過度に長い応答を生成するのを防ぎます。上記の例では、最大トークン数は2048に設定されています。

これらのパラメータは、タスクの具体的な要件や生成されるテキストの望ましい特性に基づいて調整されることがよくあります。

### AI搭載のコード自動補完 (AI-powered code autocompletion)

#### `tabAutocompleteModel`

このオブジェクトは`config.json`の`"models"`配列のものに類似していますが、常に「krugle-base-1.5b-local」のような小型のコードベースモデルを選択してください。

#### `tabAutocompleteOptions`

このオブジェクトでは、コード自動補完の動作をカスタマイズできます。利用可能なオプションは次のとおりです：

- `useCopyBuffer`: プロンプトを構築する際にコピー バッファを考慮するかどうかを決定します。（ブール値）
- `useFileSuffix`: プロンプトにファイルの接尾辞を使用するかどうかを決定します。（ブール値）
- `maxPromptTokens`: 使用するプロンプトトークンの最大数。小さい数値ほど高速な補完が得られますが、文脈は少なくなります。（数値）
- `debounceDelay`: キーストローク後に自動補完をトリガーするまでの遅延（ミリ秒）。（数値）
- `maxSuffixPercentage`: プロンプトに割り当てられる接尾辞の最大割合。（数値）
- `prefixPercentage`: 入力に割り当てるべき接頭辞の割合。（数値）
- `template`: 接頭辞と接尾辞の変数を使用して、Mustache テンプレート言語でレンダリングされる自動補完用のオプションのテンプレート文字列。（文字列）
- `multilineCompletions`: 複数行の補完を有効にするかどうか（「always」、「never」、または「auto」）。デフォルトは「auto」です。

#### 例

デフォルトのコード自動補完設定は次のとおりです。この設定がconfig.jsonファイルに見つからない場合は、手動で`tabAutocompleteModel`の設定をconfig.jsonにコピーして追加できます。

```json
"models": [
 ...
],
"tabAutocompleteModel": {
  "title": "KrugleAI Code 10B",
  "provider": "krugle-shasta",
  "model": "krugle-code-10b",
  "contextLength": 16384,
  "completionOptions": {
    "temperature": 0.7,
    "topK": 45,
    "topP": 0.75,
    "maxTokens": 2048
  }
},
"tabAutocompleteOptions": {
 "useCopyBuffer": false,
 "maxPromptTokens": 400,
 "prefixPercentage": 0.5
}
```

#### コードオートコンプリートのトグル

KLiPのコードオートコンプリート機能を有効または無効にするには、VSCodeのステータスバーにあるKLiPボタンをクリックします。その後、ドロップダウンメニューから「オートコンプリートを有効にする」または「オートコンプリートを無効にする」を選択します。

![](autocomplete.png)

### コンテキストプロバイダー (Context Providers)

コンテキストプロバイダーを使用すると、単に「@」を入力することで、言語モデル（LLM）用のコンテキストとして使用できるコンテンツのドロップダウンメニューにアクセスできます。各コンテキストプロバイダーはプラグインとして機能します。利用可能な情報源を参照する必要がある場合は、新しいコンテキストプロバイダーをKrugleサポートチームにリクエストできます。

例えば、新しいGitHub Issueに対処しているとします。「@issue」と入力し、関連するものを選択します。これにより、KLiPはそのIssueのタイトルと内容にアクセスできます。もしそのIssueが「readme.md」や「foobar.py」といったファイルに関連している場合、「@readme」と「@foobar」と入力してそれらを見つけて選択できます。その結果、これらの3つの「コンテキストアイテム」があなたの入力にシームレスに統合されます。

<img width="449" alt="image" src="context.png">

#### ビルトインコンテキストプロバイダー

ビルトインのコンテキストプロバイダーを使用するには、config.jsonに移動し、contextProvidersリストに追加します。

##### ファイル

`@file`を入力して、現在のワークスペース内の任意のファイルを参照します。

```json
{ "name": "file" }
```

##### 開いているファイル

`@open`を使用して、すべての開いているファイルの内容にアクセスします。`onlyPinned`を`true`に設定すると、ピン留めされたファイルのみを参照できます。

```json
{ "name": "open", "params": { "onlyPinned": true } }
```

##### コード

`@code`を使って、プロジェクト全体から特定の関数やクラスを参照します。

```json
{ "name": "code" }
```

##### Git Diff

`@diff`を使用して、現在のブランチで行われたすべての変更を参照します。これは、作業の要約やコミット前の一般的なレビューを依頼する際に便利です。

![](diff.png)

```json
{ "name": "diff" }
```

##### コードベースの取得

`@codebase`を用いて、コードベースから最も関連性の高いスニペットを自動的に取得します。

```json
{ "name": "codebase" }
```

**設定**

コードベースコンテキストプロバイダーの動作は、いくつかのオプションで構成できます。これらの設定は、`@codebase`および`@folder`のコンテキストプロバイダーの両方に適用され、config.jsonで調整できます。

**ファイルの場所:** `~/.klip/config.json`

```json
{
  "contextProviders": [
    {
      "name": "codebase",
      "params": {
        "nRetrieve": 25,
        "nFinal": 5,
        "useReranking": true
      }
    }
  ]
}
```

- **`nRetrieve`:** 最初にベクターデータベースから取得する結果の数（デフォルト：25）。

- **`nFinal`:** 再ランキング後に使用する最終的な結果の数（デフォルト：5）。

- **`useReranking`:** 再ランキングを使用するかどうか。最初に `nRetrieve` の結果を選択し、その後LLMを使用して上位 `nFinal` の結果を選ぶ（デフォルト：true）。

**インデックス作成時のファイル無視**

KLiPは、どのファイルをインデックスしないかを判断するために `.gitignore` ファイルを尊重します。追加のファイルを除外するには、同様のルールに従った `.klipignore` ファイルを作成できます。

インデックスの強制的な更新を行うには、`cmd/ctrl + shift + P`を押してVS Codeウィンドウをリロードしてください。その後、「ウィンドウをリロード」を選択します。

##### フォルダ

`@folder` と入力すると、`@codebase` と同じ取得メカニズムが使用されますが、単一のフォルダに制限されます。

```json
{ "name": "folder" }
```

##### ワークスペース内の正確な検索（RegExpパターン）

`@search` と入力すると、VS Codeでの検索結果と同様のコードベース検索の結果を参照できます。

> 注: このコンテキストプロバイダーのデータサイズが大きくなる可能性があるため、GPUアクセラレーションなしでShastaをローカルにデプロイすると性能が低下することがあります。そのため、GPUを使用してShastaをローカルにデプロイするか、GPUインスタンス上でリモートデプロイされたKrugleAI Base Proサービスを使用することをお勧めします。
>
##### ファイルツリー

`@tree` と入力すると、現在のワークスペースの階層構造を参照できます。これにより、LLMはプロジェクトの入れ子のディレクトリレイアウトを表示できます。

> 注: このコンテキストプロバイダーのデータサイズが大きくなる可能性があるため、GPUアクセラレーションなしでShastaをローカルにデプロイすると性能が低下することがあります。そのため、GPUを使用してShastaをローカルにデプロイするか、GPUインスタンス上でリモートデプロイされたKrugleAI Base Proサービスを使用することをお勧めします。

##### URL

`@url` と入力し、URLを入力します。KLiPはこれをMarkdown文書に変換します。

```json
{ "name": "url" }
```

##### ドキュメント

任意のドキュメントサイトからスニペットをインデックスして取得するには、`@docs` と入力します。

```json
{ "name": "docs" }
```

**単一のドキュメントサイトを追加**

単一のドキュメントサイトを追加するには、`@docs` コンテキストプロバイダーを使用することをお勧めします。ドロップダウンから「ドキュメントを追加」を選択し、サイトのルートURLと参照用のタイトルを入力します。インデックス作成には時間がかかる場合があります。

![](docs.png)

サイトがインデックスされると、`@docs` と入力し、ドロップダウンからドキュメントを選択すると、KLiPが自動的に類似性検索を使用してクエリに関連するセクションを見つけます。

<img width="500" alt="image" src="docs2.png">

![](docs3.png)

使用したコンテキストをクリックすると、ソースドキュメントが表示されます。

<img width="1065" alt="image" src="docs4.png">

KLiPは、いくつかの一般的なドキュメントサイトも事前にインデックスします。これらのサイトの埋め込みは当社がホストし、最初のリクエスト後にローカルにダウンロードされます。それ以外のインデックス作成はすべてローカルで行われます。ファイアウォールで `krugle-klip.s3.ap-northeast-1.amazonaws.com` のドメインをホワイトリストに追加してください。

**config.jsonを介して複数のドキュメントサイトを追加**

複数のドキュメントサイトを追加するには、`config.json` ファイルを更新します。ファイルが保存されるとインデックス作成が開始されます。

`config.json` ファイルを次のように更新します：

```json
{
  "docs": [
    {
      "startUrl": "https://nextjs.org/docs",
      "title": "Next.js",
      "faviconUrl": "https://nextjs.org/favicon.ico"
    }
  ]
}
```

- `title`: ドキュメントサイトの名称で、UI内での識別に使用されます。
- `startUrl`: インデックス作成が開始されるURLです。
- `rootUrl`: サイトの基本URLで、インデックス作成対象のページを特定するために使用されます。
- `faviconUrl`: サイトのファビコンURLで、UI内での視覚的識別に使用されます。

設定ファイルが更新されると、ドキュメントは自動的にインデックスされます。ただし、インデックス作成が無効になっている場合は除きます。手動でインデックスをトリガーするには、VSCodeのコマンドパネルで`Klip: Docs Index`コマンドを使用してください（`Shift + Cmd/Ctrl + P`を押します）。強制的にインデックスを作成するには、`Klip: Docs Force Re-Index`を使用します。これらのコマンドは、自動インデックス作成が無効になっていても機能します。

<img width="560" alt="image" src="docs5.png">

**動的生成サイトのクロール**

デフォルトでは、JavaScriptレンダリングを必要としないドキュメントサイトをクロールするために軽量なツールを使用します。

動的に生成されたサイトをクロールする必要がある場合やエラーが発生した場合は、`config.json`で実験的な`useChromiumForDocsCrawling`機能を有効にしてください。これにより、KLiPキャッシュディレクトリにChromiumがダウンロードおよびインストールされます。

```json
"experimental": {
  "useChromiumForDocsCrawling": true
}
```

##### ターミナル (Terminal)

`@terminal`を使用して、IDEのターミナルの内容にアクセスします。

```json
{ "name": "terminal" }
```

##### GitHubの課題 (GitHub Issues)

`@issue`を入力して、GitHubの課題内の会話を直接参照します。レート制限を避けるために、自分の[GitHub個人アクセストークン](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token)を必ず含めてください：

```json
{
  "name": "issue",
  "params": {
    "repos": [
      {
        "owner": "krugle2",
        "repo": "klip"
      }
    ],
    "githubToken": "ghp_xxxxxxxxxxxx"
  }
}
```

##### GitLab マージリクエスト (GitLab Merge Request)

現在のブランチのオープンなマージリクエスト (MR) を GitLab で参照するには、`@gitlab-mr` と入力してください。

**設定**

`read_api` スコープを持つ [個人アクセストークン](https://docs.gitlab.com/ee/user/profile/personal_access_tokens.html) を作成し、次の情報を設定に追加してください。

```json
{
  "name": "gitlab-mr",
  "params": {
    "token": "..."
  }
}
```

**セルフホステッド GitLab の使用**

セルフホステッドの GitLab インスタンスと通信するには、設定内の `domain` パラメータを設定してください。デフォルトでは `gitlab.com` に設定されています。

```json
{
  "name": "gitlab-mr",
  "params": {
    "token": "...",
    "domain": "gitlab.example.com"
  }
}
```

**コメントのフィルタリング**

特定のコードを編集している場合、`filterComments` を `true` に設定することで、他のファイルからのコメントを除外できます。

##### Jira 課題 (Jira Issues)

Jira 課題の会話を参照するには、`@jira` と入力してください。自分の [Atlassian API トークン](https://id.atlassian.com/manage-profile/security/api-tokens) を含めるか、`email` と `token` を使用し、トークンを基本認証のパスワードとして設定してください。独自の Atlassian API トークンを使用している場合は、メールアドレスを設定する必要はありません。

```json
{
  "name": "jira",
  "params": {
    "domain": "company.atlassian.net",
    "token": "ATATT..."
  }
}
```

**Jira データセンターのサポート (Jira Datacenter Support)**

このコンテキストプロバイダーは、Jira API バージョン 2 と 3 の両方をサポートしています。デフォルトではバージョン 3（クラウド版）が使用されますが、Jira データセンター版を使用している場合は、`apiVersion` プロパティを使用して API バージョンを 2 に設定する必要があります。

```json
  "params": {
    "apiVersion": "2",
    ...
  }
```

**問題のクエリ (Issue Query)**

デフォルトでは、以下のクエリが使用されて問題を検索します：

```
assignee = currentUser() AND resolution = Unresolved order by updated DESC
```

`issueQuery`パラメーターを設定することで、このクエリを上書きできます。

##### オペレーティングシステム

`@os`を入力することで、現在のオペレーティングシステムのアーキテクチャとプラットフォームを参照できます。

```json
{ "name": "os" }
```

##### Krugle Enterpriseファイル - 作業中、近日公開

`@krugle`を使用して、Krugle Enterprise検索インデックス内のファイルを直接参照します。

##### PostgreSQL - 作業中、近日公開

テーブルのスキーマとサンプル行を参照するには、`@postgres`と入力します。

##### データベーステーブル - 作業中、近日公開

`@database`を入力してテーブルスキーマを参照します。ドロップダウンメニューを使用するか、構成に基づいてテーブル名を入力し始めることができます。

##### デバッガー：ローカル変数 - 作業中、近日公開

スレッドのコールスタックの上位nレベル（デフォルトは3）のローカル変数を参照するには、`@local`と入力します。

##### コンテキストプロバイダーのリクエスト

必要な情報が見つからない場合は、Krugleサポートチームに連絡するか、[こちら](https://github.com/krugle2/Klip/issues/new)で新しいコンテキストプロバイダーをリクエストする問題を作成してください。

### スラッシュコマンド (Slash Commands)

スラッシュコマンドは、'/'と入力してドロップダウンから選択することでアクティブ化されるショートカットです。たとえば、組み込みの`/edit`スラッシュコマンドを使用すると、エディタに直接変更をストリーミングできます。

<img width="451" alt="image" src="slash.png">

#### 組み込みスラッシュコマンド

組み込みスラッシュコマンドを使用するには、config.jsonを開いて`slashCommands`リストに追加します。

##### /edit

コードを`cmd/ctrl + L`で選択し、次に"/edit"と入力して編集の指示を続けます。KLiPは、変更をサイドバイサイドの差分エディタにストリーミングします。

```json
{
  "name": "edit",
  "description": "Edit highlighted code"
}
```

##### /comment

`/comment`は`/edit`と似ていますが、コードにコメントを追加するようにLLMに自動的に指示します。

```json
{
  "name": "comment",
  "description": "Write comments for the highlighted code"
}
```

##### /share

"/share"を入力すると、現在のチャット履歴の共有可能なMarkdown形式のトランスクリプトが生成されます。

```json
{
  "name": "share",
  "description": "Download and share this session"
}
```

##### /cmd

自然言語からシェルコマンドを生成し、（VS Codeのみ）自動的にターミナルに貼り付けます。

```json
{
  "name": "cmd",
  "description": "Generate a shell command"
}
```

##### /commit

現在のgit diffをLLMに表示し、コミットメッセージを生成するよう依頼します。

```json
{
  "name": "commit",
  "description": "Generate a commit message for the current changes"
}
```

#### カスタムコマンドの自然言語使用 (非推奨)

> この機能は非推奨です。代わりにプロンプトカスタマイズ機能を使用してください。

`config.json`の`customCommands`プロパティに追加することで、カスタムスラッシュコマンドを追加できます。

- `name`: コマンドの名前。`/name`で呼び出されます。
- `description`: ドロップダウンに表示されるコマンドの簡潔な説明。
- `prompt`: プロンプトに表示されるLLMへの指示。

カスタムコマンドは、プロンプトを頻繁に再利用するのに役立ちます。例えば、コードのミスをチェックするためのプロンプトを作成した場合、以下のようなコマンドを追加できます。

***config.json***

```json
customCommands=[{
 "name": "check",
 "description": "Check for mistakes in my code",
 "prompt": "Please review the selected code for any errors. Be thorough in your examination, paying close attention to the following:\n- Syntax errors\n- Logic errors\n- Security vulnerabilities\n- Performance issues\n- Anything else that looks wrong\n\nWhen identifying an error, succinctly explain it without unnecessary elaboration. For instance, instead of saying 'I think there is a syntax error on line 5', you should state 'Syntax error on line 5'. Present your findings as individual bullet points for each mistake discovered."
}]
```

---

## FAQ

### KLiPが有効化されない理由

#### 無効な資格情報

Krugle Enterpriseサーバーが認証を有効にしている場合、KLiPから「`無効な資格情報`」のエラーが表示されます。例：

![](faq1.png)

これは、あなたのKrugle Enterpriseの資格情報が正しくないことを意味します。KLiPのVSCode設定ページでユーザー名を確認し、パスワードを再入力してください。

Krugle Enterpriseサーバーに認証が不要な場合は、ユーザー名のフィールドを空白のままにしてください。

![](faq2.png)

### KLiPが文字化けしたテキストを出力し続ける理由

まず`shasta.log`ファイルを確認してください。macOSまたはWindowsでは、`$SHASTA_HOME/shasta.log`にあります。Linuxでは、`/var/log/shasta/shasta.log`にあります。以下のエラーが表示された場合は、マシンのRAMが不足していることを示しています。

```log
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
```

**解決策:**

KLiPの`config.json`ファイル内の`contextLength`および`maxTokens`パラメータを調整してください。以下は一例です： `16384/4096`, `8192/4096`, `8192/2048`, `4096/2048`, `2048/1024`, `2048/512`, `1024/512`。

```json
  {
    "title": "KrugleAI Code 10B",
    "provider": "krugle-shasta",
    "model": "krugle-code-10b",
    "apiBase": "http://127.0.0.1:5668",
    "contextLength": 16384,
    "template": "krugle-10b-en",
    "completionOptions": {
      "temperature": 0.7,
      "topK": 45,
      "topP": 0.75,
      "maxTokens": 4096
    }
  }
```

### どのファイルをインデックスから除外するかをカスタマイズするには？

Klipは、インデックスに含めないファイルを決定するために`.gitignore`ファイルのルールに従います。追加で除外したいファイルがある場合は、それらを`.klipignore`ファイルに追加できます。このファイルは`.gitignore`と同じルールに従います。

たとえば、プロジェクトのトップレベルに`.klipignore`ファイルを追加できます。

```shell
.vscode/
node_modules/
dist
media
.git
*.log

# 他のルールをここに追加してください
# ...
```

### なぜShastaはすべてのCPUコアを使用していないのか？

単純に`numThreads`オプションを追加してください。

```json
  {
    "title": "KrugleAI Code 10B",
    "provider": "krugle-shasta",
    "model": "krugle-code-10b",
    "apiBase": "http://127.0.0.1:5668",
    "contextLength": 16384,
    "template": "krugle-10b-en",
    "completionOptions": {
      "temperature": 0.7,
      "topK": 45,
      "topP": 0.75,
      "maxTokens": 4096,
      "numThreads": 8
    }
  }
```

### コード補完が表示されない

正しく設定されていることを確認するために、以下の手順を実行してください：

1. 「Tabオートコンプリートを有効にする」設定がチェックされていることを確認してください（VS Codeでは、ステータスバーの「Klip」ボタンをクリックして切り替えます）。
2. Shastaがインストールされ、設定され、実行されていることを確認してください。
3. `shasta ls`を実行して、モデルがダウンロードされているか確認してください。
4. 他の補完プロバイダーを無効にしてください。これらが干渉する可能性があります。
5. KLiPをチャットに同時に使用しないでください。これにより、Shastaがメモリからモデルを繰り返しロードおよびアンロードし、両方の応答が遅くなるか、まったく応答しなくなります。
6. ログ出力に潜在的なエラーがないか確認してください（`cmd/ctrl + shift + P` -> 「開発者ツールの切り替え」 -> VS Codeの「コンソール」タブ）。
7. それでも問題が解決しない場合は、お知らせください。できるだけ早くサポートいたします。

### 補完が遅い

これはハードウェアに依存します。

### 補完が私のコードを認識しない

このシステムの精度向上に取り組んでおり、今後数週間で大幅な改善を期待しています。

### 補完にフォーマットエラーが含まれている

繰り返し発生するエラーのパターンに気づいた場合は、お知らせください。できるだけ早く対処し、修正いたします。

### Quick Lensツールが表示されないのはなぜですか？

開いているファイルの言語の[Language Server Protocol](https://microsoft.github.io/language-server-protocol/)拡張がインストールされている必要があります。VSCodeにその言語のLanguage Server Protocolサポートがない場合は、VSCodeの拡張マーケットプレイスで「Language Server Protocol」を検索してください。

---

ライセンス

[© 2024 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
