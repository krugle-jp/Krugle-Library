# KrugleAI KLiP ユーザーガイド

**バージョン**: v0.7.0-beta

<div align="center">
<img width="500" alt="KLiP" src="logo.png">
</div>

- [KrugleAI KLiP ユーザーガイド](#krugleai-klip-ユーザーガイド)
  - [はじめに](#はじめに)
  - [機能](#機能)
    - [コードを素早く簡単に理解する](#コードを素早く簡単に理解する)
    - [クラス、ファイルなどをコンテキストに追加](#クラスファイルなどをコンテキストに追加)
    - [インライン編集](#インライン編集)
    - [AI搭載のコード自動補完](#ai搭載のコード自動補完)
    - [組織のコードとドキュメントを参照](#組織のコードとドキュメントを参照)
    - [コードベース検索](#コードベース検索)
    - [ドキュメントとチャット](#ドキュメントとチャット)
    - [エージェンティックコーディング体験](#エージェンティックコーディング体験)
    - [すべてのMCPツールをサポート](#すべてのmcpツールをサポート)
    - [独自のプロンプトをカスタマイズ](#独自のプロンプトをカスタマイズ)
      - [クイックスタート](#クイックスタート)
      - [フォーマット](#フォーマット)
        - [YAML設定](#yaml設定)
        - [プロンプト本文](#プロンプト本文)
    - [履歴](#履歴)
    - [モデルカスタマイズ](#モデルカスタマイズ)
    - [ダッシュボード](#ダッシュボード)
  - [クイックスタート (Quickstart)](#クイックスタート-quickstart)
  - [KLiPの使い方](#klipの使い方)
    - [要約](#要約)
    - [KLiPを使用するタイミング](#klipを使用するタイミング)
      - [複雑な編集の簡素化](#複雑な編集の簡素化)
      - [ファイルを一から作成する](#ファイルを一から作成する)
      - [ボイラープレートを一から作成する](#ボイラープレートを一から作成する)
      - [選択したコードを修正する](#選択したコードを修正する)
      - [選択したコードまたはファイル全体について質問する](#選択したコードまたはファイル全体について質問する)
      - [エラーへの対処](#エラーへの対処)
      - [適切なシェルコマンドの決定](#適切なシェルコマンドの決定)
      - [単一ターンのオープンエンドな質問をする](#単一ターンのオープンエンドな質問をする)
      - [小さな既存ファイルの編集](#小さな既存ファイルの編集)
      - [複数ファイルからのコンテキストの活用](#複数ファイルからのコンテキストの活用)
      - [少ないステップでタスクを実行する](#少ないステップでタスクを実行する)
    - [KLiPを使用しないタイミング](#klipを使用しないタイミング)
      - [詳細なデバッグ](#詳細なデバッグ)
      - [複数ファイルの並行編集](#複数ファイルの並行編集)
      - [ファイル全体のコンテキストの使用](#ファイル全体のコンテキストの使用)
      - [大きなファイルの編集](#大きなファイルの編集)
      - [非常に長い行の選択](#非常に長い行の選択)
      - [多数のステップを含むタスク](#多数のステップを含むタスク)
  - [設定](#設定)
    - [ライセンス](#ライセンス)
    - [モデル](#モデル)
      - [チャット](#チャット)
        - [エージェントモード](#エージェントモード)
        - [関連質問を表示](#関連質問を表示)
      - [オートコンプリート](#オートコンプリート)
        - [コードオートコンプリートの切り替え](#コードオートコンプリートの切り替え)
      - [編集](#編集)
      - [適用](#適用)
      - [埋め込み](#埋め込み)
    - [コードベースのインデックス作成](#コードベースのインデックス作成)
    - [ドキュメント](#ドキュメント)
    - [外観](#外観)
  - [YAML設定ファイル](#yaml設定ファイル)
    - [models](#models)
    - [context](#context)
    - [rules](#rules)
      - [.kliprules](#kliprules)
    - [prompts](#prompts)
    - [docs](#docs)
    - [mcpServers](#mcpservers)
    - [YAML設定の完全なサンプル](#yaml設定の完全なサンプル)
  - [コンテキストプロバイダー](#コンテキストプロバイダー)
    - [ファイル](#ファイル)
    - [開いているファイル](#開いているファイル)
    - [現在のファイル](#現在のファイル)
    - [コード](#コード)
    - [Git 差分](#git-差分)
    - [Git コミット](#git-コミット)
    - [コードベース](#コードベース)
    - [フォルダ](#フォルダ)
    - [正規表現パターンによるワークスペース内の厳密な検索](#正規表現パターンによるワークスペース内の厳密な検索)
    - [ファイルツリー](#ファイルツリー)
    - [URL](#url)
    - [ドキュメンテーション](#ドキュメンテーション)
    - [クリップボード](#クリップボード)
    - [ターミナル](#ターミナル)
    - [GitHub Issues](#github-issues)
    - [GitLab マージリクエスト](#gitlab-マージリクエスト)
    - [Jira Issues](#jira-issues)
    - [オペレーティングシステム](#オペレーティングシステム)
    - [コードベーススケルトン](#コードベーススケルトン)
    - [問題](#問題)
    - [KrugleKnow](#krugleknow)
    - [PostgreSQL - 開発中、近日公開予定](#postgresql---開発中近日公開予定)
    - [データベーステーブル - 開発中、近日公開予定](#データベーステーブル---開発中近日公開予定)
    - [Web検索](#web検索)
    - [デバッガー：ローカル変数](#デバッガーローカル変数)
    - [コンテキストプロバイダーのリクエスト](#コンテキストプロバイダーのリクエスト)
  - [よくある質問](#よくある質問)
    - [KLiPが文字化けした出力を続ける理由](#klipが文字化けした出力を続ける理由)
    - [インデックスに含めるファイルをカスタマイズする方法](#インデックスに含めるファイルをカスタマイズする方法)
    - [Shastaが常にすべてのCPUコアを使用しない理由](#shastaが常にすべてのcpuコアを使用しない理由)
    - [Shastaが常にGPUを使用しない理由](#shastaが常にgpuを使用しない理由)
      - [100% GPU使用率](#100-gpu使用率)
      - [部分的なCPU/GPU使用率](#部分的なcpugpu使用率)
    - [コード補完が表示されない](#コード補完が表示されない)
    - [自動補完が遅い](#自動補完が遅い)
    - [自動補完が私のコードを認識しない](#自動補完が私のコードを認識しない)
    - [自動補完にフォーマットエラーが含まれる](#自動補完にフォーマットエラーが含まれる)


## はじめに

KLiPはソフトウェア開発のために設計されたエンタープライズコードオートパイロットツールで、KrugleAIの機能をIDEに統合します。

KLiPを使用すると、KrugleAIの強力なコード言語モデル（LLM）を直接IDE内で活用しながら、生成された回答をシームレスにコードベースに組み込むことができます。

達成できることの例として以下があります：

- `cmd/ctrl + I`を使用して自然言語からボイラープレートコードを生成します。
- コードを選択し、リファクタリング手順を説明すると、変更がエディタに即座に適用されます。
- コードベースに関する高レベルの質問を投げかけると、KLiPが自動的に関連ファイルを特定します（アルファ版）。
- 任意の関数やクラスに対して効率的に単体テストを生成します。
- エディタを離れることなく、クイック質問に即座に回答を得ることができます。
- コンパイラの範囲を超えたエラーについて、現在の変更をレビューしてもらえます。
- ***@***を入力するだけで、LLMとの通信中に様々なソースを参照できます。今後追加されるコンテキストプロバイダには、`@docs`（コード言語とフレームワークのドキュメント用）、`@krugle`（KrugleKnowプラットフォームにインデックス化されたファイルやドキュメント用）、`@jira`（Jiraの課題参照用）などがあります。
- 特定のワークフローに合わせて拡張機能をカスタマイズするための広範な構成オプションを提供しています。
- インラインの提案や迅速なボイラープレートコードの作成のためのローカルタブ自動補完機能を利用できます（アルファ版）。

## 機能

### コードを素早く簡単に理解する

![](code_explanation.gif)

コードの一部分が分かりにくい場合でも、KLiPがそれを分解して、デバッグと理解を速める明確で簡潔な説明を提供します。

`cmd + L`（Mac）または`ctrl + L`（Windows）を押して、作業中のコードに関する洞察を得ることができます。

### クラス、ファイルなどをコンテキストに追加

![](add_context.gif)

チャットボックスにコンテキストをコピー＆ペーストするとワークフローが中断される可能性があります。KLiPを使用すると、クラスやファイルなどを現在のコンテキストに追加でき、必要なものすべてに一箇所からアクセスできます。また、LLMの知識カットオフの問題にも対処します。

### インライン編集

作業している場所で直接コードをリファクタリングできます。

![](inline_edit_01.gif)

選択したコードに対して組み込みのインライン編集ツールが利用可能です。

![](inline_edit_02.gif)

### AI搭載のコード自動補完

KLiPはAI搭載のコード自動補完をサポートしています。Tabキーを押すだけで簡単にコード提案を取得できます。

![](ai_code_autocomplete.gif)

![](ai_code_autocomplete_02.gif)

### 組織のコードとドキュメントを参照

KrugleKnowは、組織のコードベース、コード成果物、技術文書へのフェデレーションアクセスを提供する中央検索エンジンです。柔軟な分析と検索機能を提供し、クリティカルなコードパターン、セキュリティ脆弱性、アプリケーションの問題をリアルタイムで特定できます。このプラットフォームは、技術情報に簡単にアクセスして大規模に活用できるようにすることで、開発チーム内のコラボレーションと効率を高めるように設計されています。

KLiPを使用すると、KrugleKnowプラットフォームにインデックス化された任意のコードファイルやドキュメントを、クローン作成、ダウンロード、またはローカルでインデックス化することなく検索およびブラウズできます。

![](ke_search.gif)

以下のコンテキストプロバイダ設定が`config.yaml`ファイルに必要です。

```yaml
context:
  - provider: krugleknow
```

### コードベース検索

コードベースに関する質問をします。

![](codebase_retrieval.gif)

KLiPはローカルコードベースをインデックス化し、ワークスペース全体から最も関連性の高いコンテキストを自動的に取り込むことができます。これは、埋め込みベースの検索とキーワード検索の組み合わせによって実現されます。デフォルトでは、すべての埋め込みがローカルで計算され保存されます。

コードベース検索機能は現在、「codebase」および「folder」コンテキストプロバイダを通じて利用可能です。入力ボックスで`@codebase`または`@folder`と入力してから質問することで使用できます。入力は、コードベース（またはフォルダ）の残りの部分からの埋め込みと比較され、関連するファイルが特定されます。

**一般的なユースケース：**

- **コードベースに関する高レベルな質問**
  - 「Spring securityの機能をどこかで使用していますか？」
  - 「サーバーに新しいエンドポイントを追加するにはどうすればよいですか？」
  - 「XMLをJSONに変換する既存のコードはありますか？」

- **既存のサンプルを参照としたコード生成**
  - 「`xyz`のサブクラスで見られるパターンに従って、`foo`クラスの`bar`メソッドを実装してください。」
  - 「Pythonのargparseを使用して、このプロジェクト用のCLIアプリケーションの草案を作成してください。」
  - 「既存のコンポーネントと同じパターンを使用して、ドロップダウンリスト付きの新しいVue.jsコンポーネントを生成してください。」

- **特定フォルダのクエリに`@folder`を使用**
  - 「このフォルダの主な目的は何ですか？」
  - 「Krugleのファイル検索APIはどのように使用しますか？」
  - 上記の例のいずれも、`@codebase`の代わりに`@folder`を使用できます。

**役立たない場合：**

- **LLMがコードベース内のすべてのファイルにアクセスする必要がある場合** - KrugleAI Webの使用を検討してください
  - 「`foo`関数が呼び出されている場所をすべて見つけてください。」
  - 「コードベースをレビューして、スペルミスを見つけてください。」

- **リファクタリング**
  - 「`bar`関数に新しいパラメータを追加し、その使用箇所を更新してください。」

### ドキュメントとチャット

`@docs`コンテキストプロバイダを使用すると、KLiP内で直接ドキュメントとやり取りできます。この機能により、静的サイトやGitHubのマークダウンページをインデックス化でき、コーディング中にドキュメントに簡単にアクセスして活用できるようになります。

![](docs.gif)

`@docs`コンテキストプロバイダは、指定されたドキュメントサイトをクロールし、埋め込みを生成し、ローカルに保存することで機能します。このプロセスにより、ドキュメントのコンテンツに迅速かつ効率的にアクセスできます。

また、人気のあるフレームワークやライブラリの事前インデックス化されたドキュメントサイトも提供しています。これらは`@docs`コンテキストプロバイダのドロップダウンリストから見つけることができます。

独自のドキュメントを追加するには、[こちら](#documentation)で詳細をご覧ください。

![](docs_add.gif)

### エージェンティックコーディング体験

> 警告：🚧 これは実験的機能です

エージェントはチャットモデルにツールを追加し、幅広いコーディングタスクを処理できるようにして、コンテキストを手動で検索したりアクションを実行したりする手間を省きます。チャットモデルのロール設定でエージェントモード（ツール使用）を有効または無効にできます。

![](agent.gif)

![](agent2.gif)

### すべてのMCPツールをサポート

[モデルコンテキストプロトコル（MCP）](https://modelcontextprotocol.io/introduction)は、プロンプト、コンテキスト、ツール使用を統一するためにAnthropicによって提案された標準です。KLiPは[MCP設定](#mcpservers)を通じて任意のMCPサーバーと互換性があります。

![](mcp.gif)

### 独自のプロンプトをカスタマイズ

プロンプトは、チャット中いつでも参照でき、チームと簡単に共有できる再利用可能な指示と標準化されたパターンです。特に繰り返しや複雑なタスクに役立ちます。

![](prompt_customization.gif)

#### クイックスタート

ソースコードをレビューするためのプロンプトファイルを設定する簡単な例を紹介します：

1. ワークスペースの最上位に`.klip/prompts/`という名前のフォルダを作成します。
2. このフォルダに`code-reivew.prompt`というファイルを追加します。ファイル名がプロンプトを生成するために使用するスラッシュコマンドの名前になります。
3. `code-reivew.prompt`に以下の内容を記述して保存します：

```text
name: Code Review
description: Code Review
---

Please carefully analyze the provided code and conduct a comprehensive
      code review. Please pay special attention to the following aspects and
      provide detailed analysis and improvement suggestions:
        - Syntax errors: Check for syntax issues, type mismatches, or undefined variables
        - Logic defects: Identify potential logic flaws, improper boundary condition handling, infinite loops, or performance bottlenecks
        - Security vulnerabilities: Detect SQL injection, XSS attacks, CSRF vulnerabilities, unvalidated user input, and other security risks
        - Code quality: Evaluate code readability, modularity, naming conventions, and comment completeness
        - Best practices: Point out areas that don't conform to industry best practices and provide improvement suggestions

      Please list the issues found in order of severity, and provide specific
      solutions for each problem.

@open
```

4. VSCodeを再読み込みします

このプロンプトを使用するには、レビューしたいソースコードファイルを開きます。KLiPのチャットボックスで「@prompts」と入力し、「Code Review」プロンプトを選択します。Enterを押すと、KLiPが事前定義されたプロンプトに基づいて応答を生成します。

#### フォーマット

.promptファイルは2つの部分で構成されています

1. YAML設定（「---」より上）：「temperature」や「description」などのパラメータを設定します。
2. プロンプト本文（「---」より下）：実際のプロンプト内容

##### YAML設定

「YAML設定」は`---`セパレータの上にあるすべてのもので、モデルパラメータを指定できます。YAML構文を使用し、現在は以下のパラメータをサポートしています：

- `name` - 表示タイトル
- `description` - ドロップダウンに表示される説明
- `version` - 「1」（レガシープロンプトファイル用）または「2」（これがデフォルトであり、設定する必要はありません）のいずれか

これらのパラメータが必要ない場合は、YAML設定と`---`セパレータを省略できます。

##### プロンプト本文

プロンプト本文では、以下を参照できます：

1. ファイル（ワークスペースのルートを基準とした絶対パスまたは相対パス）：

   - @CHANGELOG.md
   - @src/app/main.py
   - @/Users/someone/Desktop/some-coderepo/src/app/main.py

2. URL：

   - @<https://some.site.com>

3. コンテキストプロバイダ：
  
   - @main.py
   - @open
   - @tree
   - @skeleton
   - ...

### 履歴

履歴ページでチャット履歴を開いたり、チャットのタイトルを編集したり、チャットを削除したりできます。

<img width="400" alt="History" src="history.gif">

### モデルカスタマイズ

リモートサーバーから別のKrugleAI 15Bモデルを追加するなど、特定のニーズがある場合は、設定ページから行うことができます。

![](model_setup01.png)

KLiPは、Anthropic、DeepSeek、OpenAIのモデル、およびOpenAI APIプロトコルと互換性のある他のモデルをサポートしています。APIキーを入力し、詳細設定でAPIベースURLを設定するだけです。

![](model_setup02.png)

### ダッシュボード

ダッシュボードでは、トークン使用状況などを確認できます。

![](dashboard.png)

---

## クイックスタート (Quickstart)

1. [こちら](../Shasta/deployment_guide_ja.md)のデプロイメントガイドに従ってShastaをインストールし、[こちら](./deployment_guide_ja.md)でKLiPをインストールします。

2. インストールが完了すると、左のサイドバーにKLiPのロゴが表示されます。それをクリックすると、KLiP拡張機能が開きます。

<img width="400" alt="quick_start" src="quick_start.png">

KLiPをVS Codeの右サイドバーに移動することを強くお勧めします。これにより、KLiPを使用しながらファイルエクスプローラーに簡単にアクセスでき、サイドバーはキーボードショートカット（`cmd/ctrl + option/alt + B`）で簡単に切り替えられます。

![](dnd.gif)

3. KLiPを初めてインストールして開くと、セットアップウィザードが表示されます。

ステップ1：KrugleKnowを設定します。KrugleKnow APIのURLを入力してください。KrugleKnowサーバーで認証が有効になっている場合は、ユーザー名とパスワードを入力してください。そうでない場合は、これらのフィールドを空白のままにしておきます。

<img width="500" src="install_klip3.png">

ステップ2（任意ですが、KLiPを初めて使用する場合や0.7.0より前のバージョンを使用している場合は推奨）：Shasta/Shasta Proの設定を構成します。

<img width="500" src="install_klip4.png">

セットアップウィザードが完了すると、VSCodeが再起動します。

<img width="500" src="install_klip5.png">

4. これでインターネットから切断して、KLiPを使用したAIコード開発のパワーを活用できます。

---

## KLiPの使い方

### 要約

コーディングプロセスにLLMを適切に取り入れることで効率を向上させることができます。このガイドでは、KLiPの利用が推奨される場面と、控えた方が良い場面について説明します。

KLiPの効果は、編集や説明を生成するために使用される基盤となるKrugleAIコードLLMに依存しています。LLMが時々、存在しないライブラリや構文を導入するなど、不正確な提案をすることがあることを念頭に置いてください。提案が正しくないと思われる場合は、関連文書と照合することをお勧めします。

KLiPを使用していくうちに、その提案をいつ信頼すべきかの感覚が身につくでしょう。実験を通じて何が望ましい結果をもたらすかを理解し、KLiPに慣れることが良いアプローチです。KLiPは提案する変更を受け入れるか拒否するかを促し、必要に応じて変更を元に戻す柔軟性を提供します。

KLiPが特定のタスクに役立つかどうか不確かな場合は、以下の手順を検討してください：

'選択'とは、ファイル内のテキスト範囲を選択し、`cmd + L`（macOS）または`ctrl + L`（Windows）を押してKLiPチャットメッセージに含めることを指します。

- **選択**: `cmd/crtl + L`を使用して、より深く理解したいコードセクションを選択し、入力ボックスに「このコードの動作を教えて」と入力します。
- **評価**: 説明が合理的に思える場合、コードセクションを選択したまま、「このコードをどのように変更すれば：**[あなたのタスク]**」と尋ねてください。
- **修正**: 説明が期待に沿っている場合は、`適用`ボタンをクリックしてコードを適用できます。あるいは、コードスニペットを選び続け、`cmd/crtl + I`を押して修正コマンドを開始し、**[あなたのタスク]**を入力してコードを直接インライン修正します。
- **反復的アプローチ**: 最初の試みが望ましい結果を生まない場合は、`cmd/ctrl + shift + backspace`を使用して変更を拒否し、再試行してください。KLiPは試行ごとに異なる提案をする可能性があります。
- **明確化**: KLiPが望ましい結果を提供しない場合は、プロンプトを最適化し、より具体的な指示を提供して、期待を明確に表現してください。
- **細分化**: それでもうまくいかない場合は、タスクをより小さなサブタスクに分割し、KLiPの助けを借りるか手動で個別に対処することを検討してください。

あなた自身が書いたコードであれ、あなたが指示したLLMによって書かれたコードであれ、すべてのコードの責任はあなたにあることを忘れないでください。したがって、LLMによって生成された出力を確認することが不可欠です。このプロセスを容易にするために、KLiP GUIはLLMによって行われたアクションの自然言語による説明を提供します。

### KLiPを使用するタイミング

KLiPは、タスクを効率的に完了するのに役立つ様々なシナリオで非常に価値があります：

#### 複雑な編集の簡素化

KLiPは、従来の検索と置換の方法が不十分な状況で特に効果的です。例えば、インライン編集`cmd/crtl + I`「これらすべてをそのように変更する」などです。

**例**

- `cmd/crtl + I`「この場所で縦棒を'Union'に置き換える」
- `cmd/crtl + I`「ここでより説明的な変数名を使用して読みやすさを向上させる」

#### ファイルを一から作成する

KLiPは、Reactコンポーネント、Pythonスクリプト、シェルスクリプト、Makefile、ユニットテストなど、さまざまなファイルタイプの作成プロセスを合理化します。

**例**

- `cmd/crtl + I`「ニューヨーク・タイムズから最新ニュースを取得するPythonスクリプトを作成する」
- `cmd/crtl + I`「構文強調表示されたコード用のReactコンポーネントを統合する」

#### ボイラープレートを一から作成する

KLiPはさらに、ボイラープレート構造の作成を支援する機能を拡張しています。例えば、引数をソートして表示するためのtyper CLIアプリを備えたPythonパッケージのフレームワークを構築するのに役立ちます。

**例**

- `cmd/crtl + I`「このスキーマを使用して、最近解約したユーザーを取得するSQLクエリを生成する」
- `cmd/crtl + I`「ホームディレクトリを/tmp/にバックアップするシェルスクリプトを開発する」

#### 選択したコードを修正する

コードのセクションを選択した後、KLiPを使用してそれを改良することを目指します（例：`cmd/crtl + I`「関数がこの方法で動作するように修正する」または`cmd/crtl + I`「これを普遍的に実装する」）。

**例**

- `cmd/crtl + I`「このDigital OceanのTerraformファイルをGCPで機能するように適応させる」
- `cmd/crtl + I`「この関数を非同期に書き直す」

#### 選択したコードまたはファイル全体について質問する

特定のコードがどのように動作するか不確かな場合は、それを選択して「このコードはどのように動作しますか？」と尋ねます。

**例**

- 「ページのどこでバックエンドへのリクエストを行うべきですか？」
- 「これらのiframe間の通信をどのように促進できますか？」

#### エラーへの対処

KLiPはエラー/例外を説明し、潜在的な解決策を提案するのに役立ちます。ターミナルでエラー/例外に遭遇したら、`cmd + shift + R`（macOS）/`ctrl + shift + R`（Windows）を押します。この操作により、スタックトレースがKLiPに送信され、問題の説明が促されます。

#### 適切なシェルコマンドの決定

焦点を変えて気が散ることなく、「ポート8000で実行中のプロセスを識別するにはどうすればよいですか？」などの質問ができます。

**例**

- 「load_dotenvライブラリの名前は何ですか？」
- 「ポート8000で実行中のプロセスを識別するにはどうすればよいですか？」

#### 単一ターンのオープンエンドな質問をする

IDEを離れる代わりに、マルチターンの会話にならないと予想されるオープンエンドな質問をすることができます。

**例**

- 「カスケード削除を設定するためのPrismaスキーマをどのように設定しますか？」
- 「密な埋め込みと疎な埋め込みの違いは何ですか？」

#### 小さな既存ファイルの編集

ファイルが大きすぎない限り、ファイル全体を選択してKLiPに改善を依頼することができます。

**例**

- `cmd/crtl + I`「これはPostgreSQLのコネクタです、Kafkaのコネクタを作成してください」
- `cmd/crtl + I`「このAPIコールを全ページを取得するように修正する」

#### 複数ファイルからのコンテキストの活用

手動での変更と同様に、一度に一つのファイルに集中します。ただし、他のファイルに関連情報が含まれている場合は、追加のコンテキストとして使用するためにそれらのコードセグメントも選択します。

#### 少ないステップでタスクを実行する

Klipは、完了するために多くのステップを必要としない通常のタスクでさらに多くの支援を提供できます。

**例**

- `cmd/crtl + I`「S3への読み取り専用アクセスを持つユーザーを作成するためのIAMポリシーを生成する」
- `cmd/crtl + I`「このダッシュボードコンポーネント内でこのプロットを棒グラフに変換する」

### KLiPを使用しないタイミング

以下は、現時点でKLiPが役立たない可能性があるシナリオです：

#### 詳細なデバッグ

複雑な問題のデバッグに深く関わっていて、それが複数のファイルにまたがり約20分かかる場合、KLiPはまだすべての関連性を理解して支援できないかもしれません。ただし、進捗状況を共有し、提案を求めることで、KLiPが潜在的な解決策のアイデアを提供することがあります。

#### 複数ファイルの並行編集

現在、KLiPは一度に1つのファイルの編集しか処理できません。ただし、必要な変更を特定した後、KLiPに複数のファイルを順番に修正するよう指示することができます。

#### ファイル全体のコンテキストの使用

非常に大きなファイルの場合、KLiPはLLMコンテキストウィンドウの制限により、すべてのコンテンツを取り込むのに苦労する場合があります。完全なファイルが必要なことはまれなので、関連するコンテキストを含む特定のコードセクションを選択することを検討してください。

#### 大きなファイルの編集

同様に、一度に多くの行を編集しようとすると、コンテキストウィンドウの制限を超え、提案を適用する際にパフォーマンスが低下する可能性があります。

#### 非常に長い行の選択

過度に長い行（例：複雑なSVG）を選択すると、上記と同様の問題が発生する可能性があります。

#### 多数のステップを含むタスク

KLiPが一度にタスクを包括的に処理できない場合がありますが、それらをサブタスクに分割することで、KLiPが各ステップを支援できることがよくあります。

---

## 設定

右下隅のギアアイコンをクリックして、KLiPの設定をカスタマイズできます。

<img width="360" alt="image" src="config.png">

<img width="360" alt="image" src="config2.png">

### ライセンス

「無効化」ボタンをクリックして、ライセンスの状態を確認したり、KLiPライセンスを無効化したりできます。

<img width="300" alt="image" src="settings_license.png">

### モデル

モデルセクションで新しいモデルを追加したり、モデルの役割を管理したりできます。

#### チャット

<img width="500" alt="image" src="settings_chat.png">

「チャットモデル」は、会話形式で応答するように設計されたLLMです。一般的な質問に対応し、複雑なコードを生成するためには、通常、非常に大規模な（多くの場合4050億以上のパラメータを持つ）モデル、または特定のユースケース向けに訓練・微調整されたKrugleコードLLMのような専用コードモデルが最適です。

KLiPでは、これらのモデルは標準のチャットとVS Codeアクションに使用されます。編集または適用機能に特定のモデルが定義されていない場合、選択されたチャットモデルがそれらのタスクも処理します。

config.yamlファイルの例：

```yaml
models:
  # ...
  # ...
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  # ...
  # ...
```

##### エージェントモード

エージェントはチャットモデルにツールを追加して、幅広いコーディングタスクを処理できるようにし、コンテキストを手動で検索したりアクションを実行したりする手間を省きます。チャットモデルの役割設定でエージェントモード（ツール使用）を有効または無効にできます。

エージェントはチャットと同じインターフェースで動作するため、メッセージを送信するために同じ入力フィールドを使い続けることができます。@[コンテキストプロバイダー](#context-providers)をタグ付けしたり、エディターからコードを選択したりするコンテキスト提供の手動方法も引き続き機能します。現在エージェントモードでサポートされているモデルには、Krugle Code 15B/35B、OpenAI GPT-4o、o1、o1-mini、o3、o3-mini、およびAnthropic Claude 3.5/3.7 Sonetが含まれます。

エージェントを使用すると、自然言語で指示を出し、モデルにタスクを処理させることができます。例えば：

このプロジェクト内のすべてのeslint設定で`react/no-unescaped-entities`ルールを「off」に設定してください。

エージェントはタスクを完了するための適切なツールを決定します。

デフォルトでは、エージェントはツールを使用する前に許可を求めます。「承認」をクリックして続行するか、「キャンセル」をクリックしてアクションを拒否します。

<img width="500" alt="image" src="settings_agent2.png">

<img width="500" alt="image" src="settings_agent3.png">

エージェントが各ツールを使用する方法を、以下のオプションから選択して設定できます：

- **Allow (許可)**（デフォルト）：「キャンセル」と「承認」ボタンを表示して、ユーザーに許可を求めます。
- **Automatic (自動)**：許可リクエストをスキップします。ツールは自動的に呼び出され、その応答は直接モデルに送信されます。
- **Disabled (無効)**：ツールはモデルで使用できません。

<img width="500" alt="image" src="settings_agent.png">

##### 関連質問を表示

<img width="800" alt="image" src="settings_related.png">

関連質問の表示/非表示を切り替えます。

#### オートコンプリート

<img width="500" alt="image" src="settings_autocomplete.png">

「オートコンプリートモデル」は、fill-in-the-middle（FIM）と呼ばれる特殊な形式を使用して訓練されたLLMです。この形式では、コードスニペットの始め（プレフィックス）と終わり（サフィックス）を提供し、モデルはその間の不足している部分を予測します。タスクが狭く焦点を絞っているため、30億パラメータしかない小規模なモデルでも良好なパフォーマンスを発揮できます。対照的に、大規模なチャットモデルは、広範にプロンプトが与えられていても、このタスクに苦戦することがよくあります。

KLiPでは、オートコンプリートモデルは入力時にインラインコード提案を提供するために使用されます。これを有効にするには、config.yamlファイルでモデルの役割に「autocomplete」を含める必要があります。

config.yamlファイルの例：

```yaml
- name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - autocomplete
```

その他のオプション：

- オートコンプリートキャッシュを使用 – オートコンプリートキャッシュを有効または無効にします。
- 複数行のオートコンプリート – オートコンプリートが複数行をサポートするかどうかを制御します。オプションは`always`、`never`、または`auto`（デフォルト）です。
- ファイルでオートコンプリートを無効にする – 一致するファイルでオートコンプリートを無効にするグロブパターンのカンマ区切りリスト（例：「_/.md, */.conf」）。

##### コードオートコンプリートの切り替え

KLiPコードオートコンプリート機能を有効/無効にするには、VSCodeのステータスバーにあるKLiPボタンをクリックします。次に、ドロップダウンメニューの「オートコンプリートを有効にする」または「オートコンプリートを無効にする」を切り替えます。

![](autocomplete.png)

#### 編集

編集プロンプトには、チャットプロンプトとは異なるモデルを使用すると効果的なことが多いです。編集タスクは通常よりコードに焦点を当てており、会話の流暢さをあまり必要としないためです。したがって、Krugle Code 15B/35Bのようなコードに特化したLLMが推奨されます。

KLiPでは、モデルに「edit」の役割を割り当てて、編集リクエストを処理すべきであることを示すことができます。編集専用のモデルが定義されていない場合、システムはデフォルトで選択されたチャットモデルを使用します。

config.yamlファイルの例：

```yaml
models:
  # ...
  # ...
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  # ...
  # ...
```

#### 適用

コードを編集する際、チャットモデルと編集モデルからの出力は、既存のコードとうまく整合しないことがよくあります。「apply」の役割を持つモデルは、ファイルに変更を適用するためのより正確な差分を生成するために使用されます。

config.yamlファイルの例：

```yaml
models:
  # ...
  # ...
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  # ...
  # ...
```

#### 埋め込み

埋め込みモデルは、テキストをベクトルに変換するように設計されており、他のベクトルとの迅速な比較によってテキストの類似性を判断できます。これらのモデルは一般的に、LLMよりも小規模で、高速、およびコスト効率が良いです。

KLiPでは、埋め込みはインデックス作成中に生成され、`@Codebase`または`@docs`コンテキストプロバイダーによって、ローカルコードベースやドキュメント内で類似性検索または意味検索を実行するために使用されます。KLiPは埋め込みに2つのオプションを提供しています：

- **transformers.js** – VS Code拡張機能に統合された組み込みの埋め込みモデル。
- **shasta** – Shastaによって強化された高度な埋め込みモデル。例：

```yaml
models:
  # ...
  # ...
  - name: Krugle Text Embedding Local
    model: krugle-text-embedding
    provider: shasta
    apiBase: http://127.0.0.1:5668
    roles:
      - embed
  # ...
  # ...
```

### コードベースのインデックス作成

<img width="500" alt="image" src="settings_codebase.png">

コードベースのインデックス作成を有効または無効にしたり、インデックス作成の状態を確認したり、再インデックスをトリガーしたりできます。

### ドキュメント

<img width="500" alt="image" src="settings_docs.png">

ドキュメントのインデックス作成を追加または削除したり、インデックス作成の状態を確認したり、再インデックスをトリガーしたりできます。デフォルトでは、KLiPはJavaScriptレンダリングを必要としないドキュメントサイトをクロールするための軽量ツールを使用します。

動的に生成されるサイトをクロールする必要がある場合や、エラーが発生した場合は、`ドキュメントクロールにChromiumを使用する`を有効にできます。これにより、KLiPキャッシュディレクトリにChromiumがダウンロードされ、インストールされます。

サイトのインデックスが作成されたら、チャットボックスから`@docs`と入力し、ドロップダウンからドキュメントを選択すると、KLiPは自動的に類似性検索を使用して、クエリに関連するセクションを見つけます。

<img width="500" alt="image" src="docs2.png">

![](docs3.png)

使用されたコンテキストをクリックすると、ソースドキュメントが表示されます。

<img width="1065" alt="image" src="docs4.png">

KLiPは一般的なドキュメントサイトの多くを事前にインデックス化しています。これらのサイトの埋め込みは当社によってホストされ、最初のリクエスト後にローカルにダウンロードされます。その他のすべてのインデックス作成は完全にローカルで行われます。ファイアウォールでドメイン`krugle-klip.s3.ap-northeast-1.amazonaws.com`がホワイトリストに登録されていることを確認してください。

### 外観

<img width="500" alt="image" src="settings_appearance.png">

- **セッションタブを表示**：有効にすると、チャットの上にタブが表示され、セッションの整理とアクセスに役立ちます。デフォルトでは無効です。
- **コードブロックを折り返す**：有効にすると、コードブロック内のテキストが折り返されます。デフォルトでは無効です。
- **チャットスクロールバーを表示**：有効にすると、チャットウィンドウにスクロールバーが表示されます。デフォルトでは無効です。
- **セッションタイトル生成を無効化**：無効にすると、最初のメッセージ後に現在のチャットモデルを使用して、各チャットセッションの要約タイトルが自動的に生成されます。デフォルトでは無効です。
- **生のMarkdownを表示**：有効にすると、レスポンスが生のMarkdownテキストとして表示されます。デフォルトでは無効です。

---

## YAML設定ファイル

設定ファイル（config.yaml）は手動で作成または編集することができます。KLiP設定ページの上部にある `設定を開く (YAML)` リンクをクリックすることでアクセスできます。

<img width="300" alt="image" src="config3.png">

### models

modelsセクションでは、設定で使用する言語モデルを定義します。モデルはチャット、編集、埋め込みなどの機能に使用されます。

**プロパティ:**

- `name` (**必須**): 設定内でのモデルの一意の識別子です。
- `provider` (**必須**): モデルプロバイダー（例: `openai`, `shasta`, `anthropic`）。
- `model` (**必須**): 特定のモデル名（例: `gpt-4o`, `krugle-code-15b-chat`）。
- `apiBase`: オプション。モデルに定義されたデフォルトのAPI基本URLを上書きします。
- `roles`: モデルが実行できる役割を定義する配列で、`chat`、`autocomplete`、`embed`、`edit`、`apply`などがあります。デフォルト: `[chat, edit, apply]`。
- `capabilities`: モデルの機能を示す文字列の配列で、KLiPの自動検出を上書きします。サポートされる値には`tool_use`や`image_input`があります。
- `systemMessage`: **チャット**モードでのデフォルトのシステムプロンプトを上書きします。
- `defaultCompletionOptions`: モデル補完のデフォルト設定:
  - `contextLength`: 最大コンテキストサイズ（トークン単位）。
  - `maxTokens`: このパラメータは、モデルが1回の推論リクエストで生成できるトークンの最大数を設定します。生成されるテキストの長さを制御し、モデルが過度に長い応答を生成することを防ぎます。上記の例では、最大トークン数は2048に設定されています。
  - `temperature`: このパラメータは生成されるテキストのランダム性を制御します。低い温度値はモデルをより保守的かつ決定論的にし、より予測可能な出力を生成します。一方、高い温度値はランダム性を増加させ、より多様だがやや一貫性が低い出力をもたらします。上記の例では、温度は中立的な設定である1に設定されています。`0.0`は決定論的、`1.0`は非常にランダムです。
  - `topP`: 核サンプリングとも呼ばれ、このパラメータは累積確率質量に基づいて考慮されるトークンの数を動的に調整します。これにより、モデルは多様な出力を生成しながら、生成されたトークンの総確率質量が特定の閾値（topPで指定）を超えることを保証します。上記の例では、topPは0.75に設定されており、モデルは累積確率質量が75%を超えるまでトークンを考慮します。
  - `topK`: このパラメータは生成プロセスの各ステップで考慮されるトークンの数を制限します。確率分布に従って最も可能性の高いトップkのトークンのみを考慮するようモデルを制限します。これにより、モデルが不確かまたは無意味なトークンを生成することを防ぎます。上記の例では、topKは45に設定されており、各ステップで確率が最も高いトップ45のトークンのみが考慮されます。
  - `stop`: 生成を終了させるストップシーケンスの配列。
  - `n`: 生成する補完の数。
  - `reasoning`: Anthropic Claude 3.7+モデルの推論モードを有効にするブール値。
  - `reasoningBudgetTokens`: Anthropic Claude 3.7+モデルの推論のためのトークン予算。
- `embedOptions`: モデルが`embed`ロールを持つ場合に適用されます。埋め込み操作に使用:
  - `maxChunkSize`: ドキュメントチャンクあたりの最大トークン数（最小: 128）。
  - `maxBatchSize`: リクエストあたりの最大チャンク数（最小: 1）。

例:

```yaml
models:
  # ...
  # Krugle LLMの例
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  # 自動補完の例
  - name: Autocomplete Model
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - autocomplete

  # OpenAI互換LLMの例
   - name: My LLM
    provider: openai
    apiBase: http://localhost:8081/v1
    model: some-model
    capabilities:
      - tool_use
    roles:
      - chat
      - edit
  # Anthropic推論の例
  - name: Claude 3.7 Sonet
    model: claude-3-7-sonnet-20250219
    apiKey: sk-ant-apixxxxxxxxxxxxxxxxxxxxxxxx
    provider: anthropic
    template: anthropic
    reasoning: true
    roles:
      - chat
    defaultCompletionOptions:
      contextLength: 200000
```

### context

`context`セクションはコンテキストプロバイダーを指定し、LLMに追加情報を提供します。各プロバイダーは特定のパラメータでカスタマイズできます。

各コンテキストプロバイダーの詳細な使用法とパラメータ情報については、[コンテキストプロバイダー](#context-providers)の章を参照してください。

**プロパティ:**

- `provider` (**必須**): コンテキストプロバイダーの識別子または名前（例: `code`, `docs`, `web`）
- `name`: プロバイダーのオプションのカスタム名
- `params`: プロバイダーの動作を設定するオプションの設定。

例:

```yaml
context:
  - provider: code
  - provider: folder
  - provider: tree
  - provider: docs
  - provider: terminal
  - provider: diff
  - provider: search
  - provider: url
  - provider: open
  - provider: problems
  - provider: clipboard
  - provider: os
  - provider: debugger
  - provider: krugleknow
  - provider: skeleton
  - provider: commit
  - provider: codebase
    params:
      nFinal: 10
  - provider: web
    params:
      engine: google
      apiKey: YOUR_SERP_API_KEY
      n: 5
      country: us
      language: en
      useChromium: true
```

### rules

ルールはチャット、編集、エージェントリクエストのためにモデルに指示を提供します。これらは通常、オートコンプリートやアプライなどの他のリクエストタイプには使用されません。

rulesブロックは配列であり、各要素は単純なテキスト文字列にすることができます。

例:

```yaml
rules:
  - 回答は簡潔にしてください。明らかな概念の説明は避けてください。ほとんどのプログラミングトピックに精通していると想定してください。
```

#### .kliprules

プロジェクトのルートに.kliprulesファイルを追加することで、プロジェクト固有のルールを定義することもできます。このプレーンテキストファイルはその内容全体でconfig.yamlで設定されたルールを上書きします。

例:

```.kliprules
回答は簡潔にしてください。明らかな概念の説明は避けてください。ほとんどのプログラミングトピックに精通していると想定してください。
```

### prompts

チャットウィンドウで`/プロンプト名`を使用してトリガーできるカスタムプロンプトのリストです。各プロンプトには名前、説明、プロンプトテキスト自体が含まれます。

例:

```yaml
prompts:
  - name: inspect
    description: コード品質とセキュリティチェック
    prompt: >-
      提供されたコードを慎重に分析し、包括的なコードレビューを行ってください。以下の側面に特に注意して、詳細な分析と改善提案を提供してください：
        - 構文エラー：構文の問題、型の不一致、未定義変数をチェックする
        - 論理的欠陥：潜在的な論理の欠陥、不適切な境界条件の処理、無限ループ、またはパフォーマンスのボトルネックを特定する
        - セキュリティ脆弱性：SQLインジェクション、XSS攻撃、CSRF脆弱性、検証されていないユーザー入力、その他のセキュリティリスクを検出する
        - コード品質：コードの読みやすさ、モジュール性、命名規則、コメントの完全性を評価する
        - ベストプラクティス：業界のベストプラクティスに準拠していない領域を指摘し、改善提案を提供する

      発見された問題を重大度順にリストアップし、各問題に対する具体的な解決策を提供してください。
```

チャットウィンドウで`/inspect`コマンドを使用して、このプロンプトをアクティブにします。

### docs

インデックスを作成するドキュメントサイトのリスト。

**プロパティ:**

- `name` (**必須**): ドキュメントサイトの名前で、`@docs`ドロップダウンメニューやその他のUI要素に表示されます。
- `startUrl` (**必須**): クロールを開始するページ—通常はドキュメントのルートまたは紹介ページです。
- `maxDepth`: クロール中にたどるリンクの最大深さ。デフォルトは`4`です。
- `favicon`: サイトのファビコンのURL。デフォルトは`startUrl`に対する相対的な`/favicon.ico`です。
- `useLocalCrawling`: デフォルトのクローラをバイパスし、ローカルクローラのみを使用します。

例:

```yaml
docs:
  - name: Krugle
    startUrl: https://krugle.co.jp
    favicon: ""
```

ファイルが保存されると、インデックス作成が開始されます。

### mcpServers

[モデルコンテキストプロトコル](https://modelcontextprotocol.io/introduction)は、プロンプト、コンテキスト、ツール使用を統一するためにAnthropicによって提案された標準です。KLiPはあらゆるMCPサーバーと互換性があります。

**プロパティ:**

- `name` (**必須**): MCPサーバーの名前。
- `command` (**必須**): サーバーを起動するために使用されるコマンド。
- `args`: オプション。コマンドの引数の配列。
- `env`: オプション。サーバープロセスの環境変数のマップ。
- `connectionTimeout`: オプション。サーバー接続タイムアウト（ミリ秒）。

例:

```yaml
mcpServers:
  - name: Time
    command: uvx
    args:
      - mcp-server-time
      - --local-timezone
      - Asia/Tokyo
```

### YAML設定の完全なサンプル

```yaml
models:
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
      - autocomplete
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  - name: Krugle Text Embedding Local
    model: krugle-text-embedding
    provider: shasta
    apiBase: http://127.0.0.1:5668
    roles:
      - embed
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  - model: claude-3-7-sonnet-20250219
    apiKey: API_KEY
    provider: anthropic
    template: anthropic
    name: Claude 3.7 Sonet
    reasoning: true
    roles:
      - chat
      - edit
      - apply
    defaultCompletionOptions:
      contextLength: 200000
  - model: gpt-4o
    systemMessage: You are an expert software developer. You give helpful and
      concise responses.
    provider: openai
    apiKey: API_KEY
    name: GPT-4o
    roles:
      - chat
      - edit
      - apply
    defaultCompletionOptions:
      contextLength: 128000
context:
  - provider: codebase
    params:
      nFinal: 20
  - provider: code
  - provider: folder
  - provider: tree
  - provider: docs
  - provider: terminal
  - provider: diff
  - provider: search
  - provider: url
  - provider: open
  - provider: problems
  - provider: clipboard
  - provider: os
  - provider: debugger
  - provider: krugleknow
  - provider: skeleton
  - provider: commit
  - provider: web
    params:
      engine: google
      apiKey: YOUR_SERP_API_KEY
      n: 5
      country: us
      language: en
      useChromium: true
prompts:
  - name: inspect
    description: Code Quality and Security Check
    prompt: >-
      Please carefully analyze the provided code and conduct a comprehensive
      code review. Please pay special attention to the following aspects and
      provide detailed analysis and improvement suggestions:
        - Syntax errors: Check for syntax issues, type mismatches, or undefined variables
        - Logic defects: Identify potential logic flaws, improper boundary condition handling, infinite loops, or performance bottlenecks
        - Security vulnerabilities: Detect SQL injection, XSS attacks, CSRF vulnerabilities, unvalidated user input, and other security risks
        - Code quality: Evaluate code readability, modularity, naming conventions, and comment completeness
        - Best practices: Point out areas that don't conform to industry best practices and provide improvement suggestions

      Please list the issues found in order of severity, and provide specific
      solutions for each problem.
docs:
  - name: Krugle
    startUrl: https://krugle.co.jp
    favicon: ""
mcpServers:
  - name: Time
    command: uvx
    args:
      - mcp-server-time
      - --local-timezone
      - Asia/Tokyo
name: KLiP Assistant
version: 1.0.0
schema: v1
```

---

## コンテキストプロバイダー

コンテキストプロバイダーを使用すると、「@」を入力するだけで、言語モデル（LLM）のコンテキストとして機能するコンテンツのドロップダウンメニューにアクセスできます。各コンテキストプロバイダーはプラグインとして機能します。必要な情報ソースが利用できない場合は、Krugleサポートチームに新しいコンテキストプロバイダーをリクエストできます。

例えば、新しいGitHub Issueに対応している場合、`@issue`と入力して関連するものを選択します。これにより、KLiPはissueのタイトルと内容にアクセスできるようになります。そのissueが「readme.md」や「foobar.py」などのファイルに関連していることがわかっている場合は、`@readme`や`@foobar`と入力してそれらを見つけて選択できます。結果として、これら3つの「コンテキストアイテム」は他の入力とシームレスに統合されます。

<img width="449" alt="image" src="context.png">

組み込みのコンテキストプロバイダーを使用するには、config.yamlに移動し、contextProvidersリストに含めてください。

### ファイル

`@file`と入力して、現在のワークスペース内の任意のファイルを参照します。

```yaml
context:
  - provider: file
```

### 開いているファイル

`@open`を使用して、開いているすべてのファイルの内容にアクセスします。`onlyPinned`を`true`に設定すると、ピン留めされたファイルのみを参照します。

```yaml
context:
  - provider: open
    params:
      onlyPinned: true
```

### 現在のファイル

`@currentFile`を使用して、現在編集/表示しているファイルの内容にアクセスします。

```yaml
context:
  - provider: currentFile
```

### コード

`@code`を使用して、プロジェクト全体から特定の関数やクラスを参照します。

```yaml
context:
  - provider: code
```

### Git 差分

`@diff`を使用して、現在のブランチで行われたすべての変更を参照します。作業の概要を説明したり、コミット前に一般的なレビューをリクエストするのに役立ちます。

![](diff.png)

```yaml
context:
  - provider: diff
```

### Git コミット

`@commit`を使用して、特定のGitコミットのメタデータ、差分、または最近のすべてのコミットを参照します。

```yaml
context:
  - provider: commit
    params:
      Depth: 50
      LastXCommitsDepth: 10
```

深さはサブメニューに読み込まれるコミットの数を指定し、デフォルトは50です。LastXCommitsDepthは含まれる最近のコミットの数を決定し、デフォルトは10です。

### コードベース

`@codebase`を使用して、コードベースから最も関連性の高いスニペットを自動的に取得します。

```yaml
context:
  - provider: codebase
```

**設定**

コードベースコンテキストプロバイダーの動作はいくつかのオプションで構成できます。これらの設定は`@codebase`と`@folder`コンテキストプロバイダーの両方に適用され、`config.yaml`で調整できます：

**ファイルの場所：** `~/.klip/config.yaml`

```yaml
context:
  - provider: codebase
      params:
        nFinal: 5
        nRetrieve: 25
        useReranking: true
```

- **`nRetrieve`：** ベクトルデータベースから最初に取得する結果の数（デフォルト：25）。
  
- **`nFinal`：** 再ランク付け後に使用する最終結果の数（デフォルト：5）。

- **`useReranking`：** 再ランク付けを使用するかどうか。これは最初に`nRetrieve`結果を選択し、次にLLMを使用して上位`nFinal`結果を選択します（デフォルト：true）。

**インデックス作成中にファイルを無視する**

KLiPは`.gitignore`ファイルを尊重し、どのファイルをインデックスに含めないかを決定します。追加のファイルを除外するには、`.klipignore`ファイルを作成できます。これは`.gitignore`と同じルールに従います。

インデックスの強制更新を行うには、`cmd/ctrl + shift + P`を押してから「ウィンドウの再読み込み」を選択してVS Codeウィンドウをリロードしてください。

### フォルダ

`@folder`と入力して、`@codebase`と同じ検索メカニズムを単一のフォルダに限定して使用します。

```yaml
context:
  - provider: folder
```

### 正規表現パターンによるワークスペース内の厳密な検索

`@search`と入力して、コードベース検索の結果を参照します。これはVS Codeでの検索結果と同様です。

> 注意：このコンテキストプロバイダーのデータサイズが大きくなる可能性があるため、GPUアクセラレーションなしでShastaをローカルにデプロイすると、パフォーマンスが低下する可能性があります。そのため、GPUを搭載したShastaをローカルにデプロイするか、より高速な推論速度と改善されたパフォーマンスを得るためにGPUインスタンス上でリモートにデプロイされたKrugleAI Base Proサービスを使用することをお勧めします。

```yaml
context:
  - provider: search
```

### ファイルツリー

`@tree`と入力して、現在のワークスペースの階層構造を参照します。これによりLLMはプロジェクトのネストされたディレクトリレイアウトを表示できます。

> 注意：このコンテキストプロバイダーのデータサイズが大きくなる可能性があるため、GPUアクセラレーションなしでShastaをローカルにデプロイすると、パフォーマンスが低下する可能性があります。そのため、GPUを搭載したShastaをローカルにデプロイするか、より高速な推論速度と改善されたパフォーマンスを得るためにGPUインスタンス上でリモートにデプロイされたKrugleAI Base Proサービスを使用することをお勧めします。

```yaml
context:
  - provider: tree
```

### URL

`@url`と入力してURLを入力します。KLiPはそれをLLM用のMarkdownドキュメントに変換します。

```yaml
context:
  - provider: url
```

### ドキュメンテーション

任意のドキュメントサイトからスニペットをインデックス化して取得するには、`@docs`と入力します。

```yaml
context:
  - provider: docs
```

### クリップボード

クリップボードアイテムを参照します

```yaml
context:
  - provider: clipboard
```

### ターミナル

`@terminal`を使用して、IDEのターミナルの内容にアクセスします。

```yaml
context:
  - provider: terminal
```

### GitHub Issues

`@issue`と入力して、GitHub issues内の会話を直接参照します。レート制限を回避するために[GitHubパーソナルアクセストークン](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token)を含めてください：

```yaml
context:
  - provider: issue
    params:
      repos:
        - owner: krugle2
          repo: klip
      githubToken: ghp_xxxxxxxxxxxxxx
```

### GitLab マージリクエスト

`@gitlab-mr`と入力して、GitLab上の現在のブランチのオープンマージリクエスト（MR）を参照します。

**設定**

`read_api`スコープを持つ[パーソナルアクセストークン](https://docs.gitlab.com/ee/user/profile/personal_access_tokens.html)を作成し、次の内容を設定に追加します：

```yaml
context:
  - provider: gitlab-mr
    params:
      token: "xxxxxxxxxxxxxxxxxxxx"
```

**セルフホスティングGitLabの使用**

セルフホスティングされたGitLabインスタンスと通信するには、設定で`domain`パラメータを設定します。デフォルトでは`gitlab.com`に設定されています。

```yaml
context:
  - provider: gitlab-mr
    params:
      token: "xxxxxxxxxxxxxxxxxxxx"
      domain: "gitlab.example.com"
```

**コメントのフィルタリング**

特定のコードを編集している場合は、`filterComments`を`true`に設定して、他のファイルからのコメントをフィルタリングできます。

### Jira Issues

`@jira`と入力して、Jira issueの会話を参照します。[AtlassianのAPIトークン](https://id.atlassian.com/manage-profile/security/api-tokens)を含めるか、基本認証でパスワードとしてトークンを設定した`email`と`token`を使用してください。AtlassianのAPIトークンを使用している場合は、メールを設定しないでください。

```yaml
context:
  - provider: jira
    params:
      domain: company.atlassian.net
      token: ATATT...
```

**Jira データセンターサポート**

このコンテキストプロバイダーはJira APIバージョン2と3の両方をサポートしています。デフォルトではバージョン3（クラウドバージョン）を使用しますが、Jiraデータセンターバージョンを使用している場合は、`apiVersion`プロパティを使用してAPIバージョンを2に設定する必要があります。

```yaml
context:
  - provider: jira
    params:
      apiVersion: "2"
```

**Issue クエリ**

デフォルトでは、issueを検索するために次のクエリが使用されます：

```sql
assignee = currentUser() AND resolution = Unresolved order by updated DESC
```

`issueQuery`パラメータを設定することで、このクエリをオーバーライドできます。

### オペレーティングシステム

`@os`と入力して、現在のオペレーティングシステムのアーキテクチャとプラットフォームを参照します。

```yaml
context:
  - provider: os
```

### コードベーススケルトン

コードベースまたはサブフォルダ内のすべてのファイルの概要を提供し、各ファイルのトップレベルのクラス、関数、メソッドの主要なシンボルを強調表示します。これらのシンボルが定義されている重要なコード行を含み、モデルがコードの各部分が全体のコードベースにどのように接続されるかを理解するのに役立ちます。

```yaml
context:
  - provider: skeleton
```

### 問題

現在のファイルの問題を参照します。

```yaml
context:
  - provider: problems
```

### KrugleKnow

これはKrugleKnow検索機能を有効にするために必要です。

```yaml
context:
  - provider: krugleknow
```

### PostgreSQL - 開発中、近日公開予定

テーブルのスキーマとサンプル行を参照するには、`@postgres`と入力します。

### データベーステーブル - 開発中、近日公開予定

`@database`と入力して、テーブルスキーマを参照します。ドロップダウンメニューを使用するか、設定に基づいてテーブル名の入力を開始できます。

### Web検索

エージェントモードが有効になると、KLiPは最新のインターネットデータを使用して、より正確で最新の回答を提供できます。

config.yamlに、以下の例のように`web`コンテキストプロバイダーを追加します。[serper.dev](https://serper.dev/)で無料のAPIキーを取得できます。

```yaml
- provider: web
  params:
    engine: google
    apiKey: YOUR_SERPER_DEV_API_KEY
    n: 5
    country: us
    language: en
    useChromium: true
```

### デバッガー：ローカル変数

`@debugger`と入力して、そのスレッドのコールスタックの上位n階層（デフォルトは3）内のローカル変数を参照します。

```yaml
context:
  - provider: debugger
    params:
      stackDepth: 3
```

### コンテキストプロバイダーのリクエスト

必要なものが見つからない場合は、Krugleサポートチームに連絡するか、[こちら](https://github.com/krugle2/Klip/issues/new)で新しいコンテキストプロバイダーをリクエストするissueを作成してください。

---

## よくある質問

### KLiPが文字化けした出力を続ける理由

まずは`shasta.log`ファイルを確認してください。macOSやWindowsでは、`$SHASTA_HOME/shasta.log`に配置されています。Linuxでは、`/var/log/shasta/shasta.log`にあります。以下のようなエラーが表示されている場合は、マシンのRAMが不足していることを示しています。

```log
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
```

**解決策:**

KLiPのconfig.yamlファイルで`contextLength`と`maxTokens`パラメータを調整してください。以下は例となる値のペアです：`16384/4096`、`8192/4096`、`8192/2048`、`4096/2048`、`2048/1024`、`2048/512`、`1024/512`。

```yaml
models:
  # ...
  # ...
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
      - autocomplete
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  # ...
  # ...
```

### インデックスに含めるファイルをカスタマイズする方法

Klipはインデックスに含めないファイルを決定するために`.gitignore`ファイルのルールに従います。追加のファイルを除外するには、`.gitignore`と同じルールに従う`.klipignore`ファイルを追加できます。

例えば、プロジェクトのトップレベルに`.klipignore`ファイルを追加できます。

```shell
.vscode/
node_modules/
dist
media
.git
*.log

# 他のルールをここに追加
# ...
```

### Shastaが常にすべてのCPUコアを使用しない理由

単に`numThreads`オプションを追加してください。

```yaml
models:
  # ...
  # ...
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
      - autocomplete
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
      numThreads: 8
  # ...
  # ...
```

### Shastaが常にGPUを使用しない理由

Shastaは推論に専用GPU（NVIDIA/AMD）のVRAMを使用します。モデルパラメータの読み込みなどのタスクは、VRAMに転送する前にモデルファイルをRAMに読み込む必要があるため、CPUは常に必要とされます。

#### 100% GPU使用率

```text
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

すべてのモデルの重みがVRAMに読み込まれます。次の要因はコンテキストウィンドウのサイズです。

コンテキストウィンドウのサイズを処理するのに十分なVRAMがある場合、GPUが使用されます。そうでなければ、CPUが推論を処理します。

コンテキストウィンドウのサイズはクライアント側（AI WebまたはKLiP）で調整できます。例えば、KLiPの`config.yaml`を変更して`contextLength`を減らすことができます：

```yaml
models:
  # ...
  # ...
  - name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - chat
      - edit
      - apply
      - autocomplete
    defaultCompletionOptions:
      contextLength: 16384
      temperature: 0.7
      topK: 45
      topP: 0.75
      maxTokens: 4096
  # ...
  # ...
```

#### 部分的なCPU/GPU使用率

VRAMがほぼ満杯または完全に満杯の場合、モデルの残りの部分はシステムメモリにロードされ、CPUが無期限に推論を処理します。ただし、GPUはCPUのみを使用するよりも依然として高速で効率的です。

```shell
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

GPU使用率は100%でも、例えば空きVRAMが500 MBしかない場合があります。

または

```shell
krugle-code-10b:latest c1669e6bec24 10 GB 46%/54% CPU/GPU
```

### コード補完が表示されない

すべてが正しく設定されていることを確認するために、以下の手順に従ってください：

1. 「Enable Tab Autocomplete」設定がチェックされていることを確認します（VS Codeでは、ステータスバーの「Klip」ボタンをクリックして切り替えます）。
2. Shastaがインストール、セットアップ、実行されていることを確認します。
3. `shasta ls`を実行して、モデルがダウンロードされていることを確認します。
4. 他の補完プロバイダーが干渉する可能性があるため、それらを無効にします。
5. KLiPを同時にチャット用に使用しないでください。これにより、Shastaはメモリからモデルを繰り返し読み込みと解放することになり、両方の応答が遅くなるか応答がなくなります。
6. 潜在的なエラーがないかログ出力を確認します（VS Codeで「cmd/ctrl + shift + P」→「Toggle Developer Tools」→「Console」タブ）。
7. それでも問題がある場合は、お知らせください。できるだけ早くお手伝いします。

### 自動補完が遅い

これはハードウェアによって異なります。

### 自動補完が私のコードを認識しない

このシステムの精度を向上させるために取り組んでおり、今後数週間で大幅な改善が期待されます。

### 自動補完にフォーマットエラーが含まれる

繰り返しパターンのミスに気付いた場合は、ぜひご報告ください。できるだけ早く対処して修正します。

---

ライセンス

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
