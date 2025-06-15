# KrugleAI KLiP 用户手册

**Version**: v0.7.1-beta

<div align="center">
<img width="300" alt="KLiP" src="logo.png">
</div>

- [KrugleAI KLiP 用户手册](#krugleai-klip-用户手册)
  - [简介](#简介)
  - [功能一览](#功能一览)
    - [快速轻松理解代码](#快速轻松理解代码)
    - [将类、文件等添加到上下文中](#将类文件等添加到上下文中)
    - [内联编辑](#内联编辑)
    - [AI 驱动的代码自动补全](#ai-驱动的代码自动补全)
    - [引用您企业内部的代码和文档](#引用您企业内部的代码和文档)
    - [代码库检索](#代码库检索)
    - [与你的文档聊天](#与你的文档聊天)
    - [智能体编码体验](#智能体编码体验)
    - [支持所有 MCP 工具](#支持所有-mcp-工具)
    - [自定义你的提示](#自定义你的提示)
      - [快速入门 (Quickstart)](#快速入门-quickstart)
      - [格式](#格式)
        - [YAML 配置](#yaml-配置)
        - [提示正文](#提示正文)
    - [历史记录](#历史记录)
    - [模型自定义](#模型自定义)
    - [仪表盘](#仪表盘)
  - [快速设置](#快速设置)
  - [如何使用KLiP](#如何使用klip)
    - [简介](#简介-1)
    - [何时使用KLiP](#何时使用klip)
      - [简化复杂编辑](#简化复杂编辑)
      - [从头开始编写文件](#从头开始编写文件)
      - [从头开始创建样板代码](#从头开始创建样板代码)
      - [修复选定的代码](#修复选定的代码)
      - [询问选定的代码或整个文件](#询问选定的代码或整个文件)
      - [解决错误](#解决错误)
      - [确定适当的Shell命令](#确定适当的shell命令)
      - [提出单轮开放式问题](#提出单轮开放式问题)
      - [编辑小型现有文件](#编辑小型现有文件)
      - [利用多个文件的上下文](#利用多个文件的上下文)
      - [执行少步骤的任务](#执行少步骤的任务)
    - [何时不使用KLiP](#何时不使用klip)
      - [深入调试](#深入调试)
      - [并行编辑多个文件](#并行编辑多个文件)
      - [使用整个文件上下文](#使用整个文件上下文)
      - [编辑大文件](#编辑大文件)
      - [选择非常长的行](#选择非常长的行)
      - [具有众多步骤的任务](#具有众多步骤的任务)
  - [设置](#设置)
    - [模型](#模型)
      - [聊天](#聊天)
      - [智能体模式](#智能体模式)
        - [显示相关问题](#显示相关问题)
      - [自动补全](#自动补全)
        - [代码自动补全开关](#代码自动补全开关)
      - [编辑](#编辑)
      - [应用更改](#应用更改)
      - [嵌入](#嵌入)
    - [代码库索引](#代码库索引)
    - [文档](#文档)
    - [外观](#外观)
  - [YAML 配置文件](#yaml-配置文件)
    - [models](#models)
    - [上下文](#上下文)
    - [rules](#rules)
      - [.kliprules](#kliprules)
    - [prompts](#prompts)
    - [docs](#docs)
    - [mcpServers](#mcpservers)
    - [完整的 YAML Config 示例](#完整的-yaml-config-示例)
  - [上下文提供器](#上下文提供器)
    - [文件](#文件)
    - [打开的文件](#打开的文件)
    - [当前文件](#当前文件)
    - [代码](#代码)
    - [Git差异](#git差异)
    - [Git提交](#git提交)
    - [代码库](#代码库)
    - [文件夹](#文件夹)
    - [通过正则表达式模式在工作区内进行精确搜索](#通过正则表达式模式在工作区内进行精确搜索)
    - [文件树](#文件树)
    - [URL](#url)
    - [开发文档](#开发文档)
    - [剪贴板](#剪贴板)
    - [终端](#终端)
    - [GitHub Issues](#github-issues)
    - [GitLab合并请求](#gitlab合并请求)
    - [Jira Issues](#jira-issues)
    - [操作系统](#操作系统)
    - [代码库骨架](#代码库骨架)
    - [问题](#问题)
    - [KrugleKnow](#krugleknow)
    - [PostgreSQL - 工作进行中，即将推出](#postgresql---工作进行中即将推出)
    - [数据库表 - 工作进行中，即将推出](#数据库表---工作进行中即将推出)
    - [网络搜索](#网络搜索)
    - [调试器：局部变量](#调试器局部变量)
    - [请求上下文提供器](#请求上下文提供器)
  - [常见问题](#常见问题)
    - [为什么KLiP持续输出乱码](#为什么klip持续输出乱码)
    - [如何自定义索引哪些文件？](#如何自定义索引哪些文件)
    - [为什么Shasta不总是使用所有CPU核心？](#为什么shasta不总是使用所有cpu核心)
    - [为什么Shasta不总是使用GPU？](#为什么shasta不总是使用gpu)
      - [100% GPU使用率](#100-gpu使用率)
      - [部分CPU/GPU使用](#部分cpugpu使用)
    - [我没有看到任何代码补全](#我没有看到任何代码补全)
    - [自动补全很慢](#自动补全很慢)
    - [自动补全不了解我的代码](#自动补全不了解我的代码)
    - [自动补全包含格式错误](#自动补全包含格式错误)

## 简介

KLiP 是一款企业级代码辅助工具，专为软件开发设计，将 KrugleAI 的功能集成到您的 IDE 中。

通过 KLiP，您可以在 IDE 内利用 KrugleAI 强大的代码大语言模型，在工作流程中将生成的代码无缝整合进代码库。

以下是您可以实现的一些功能示例：

- 使用 `cmd/ctrl + I` 从自然语言生成样板代码。
- 选择代码，描述重构步骤，并在编辑器中即时应用更改。
- 提出关于代码库的高级问题，KLiP 会自动识别相关文件（alpha 版本）。
- 高效为任何函数或类生成单元测试。
- 提出快速问题以获取即时答案，无需离开编辑器。
- 审查当前更改，发现编译器范围之外的错误。
- 只需输入 ***@*** 即可在与 LLM 通信时引用各种资源。即将推出更多的上下文提供者，如 `@docs` 用于代码语言和框架文档，`@krugle` 用于 KrugleKnow 平台索引的文件或文档，`@jira` 用于引用 Jira 中的问题等。
- 我们提供广泛的配置选项，以便根据您的特定工作流程定制扩展。
- 使用我们的本地标签自动完成功能，获取内联建议并快速编写样板代码（alpha 版本）。

## 功能一览

### 快速轻松理解代码

![](code_explanation.gif)

如果你对某段代码感到困惑，KLiP 可以为你分解它，提供清晰简洁的解释，加快调试和理解速度。

按下 `cmd + L` (Mac) 或 `ctrl + L` (Windows) 即可获取关于你正在处理的代码的见解。

### 将类、文件等添加到上下文中

![](add_context.gif)

将上下文复制粘贴到聊天框中可能会打断你的工作流程。KLiP 允许你将类、文件等添加到当前上下文中，这样你就可以在一个地方访问所需的一切。它还解决了大型语言模型知识截止的问题。

### 内联编辑

直接在你工作的地方重构代码。

![](inline_edit_01.gif)

针对你选择的代码，有内置的内联编辑工具可用。

![](inline_edit_02.gif)

### AI 驱动的代码自动补全

KLiP 支持 AI 驱动的代码自动补全。只需按 Tab 键即可轻松获取代码建议。

![](ai_code_autocomplete.gif)

![](ai_code_autocomplete_02.gif)

### 引用您企业内部的代码和文档

KrugleKnow 是一个中心化企业级软件工程知识库，为企业的代码库、代码构件和技术文档提供联合访问。它提供灵活分析和搜索功能的工具，使用户能够实时识别关键代码模式、安全漏洞和应用程序问题。该平台旨在通过使技术信息易于大规模访问和操作，增强开发团队内的协作和效率。

使用 KLiP，你可以搜索和浏览 KrugleKnow 平台中索引的任何代码文件或文档，而无需在本地克隆、下载或索引它们。

![](ke_search.gif)

在 `config.yaml` 文件中需要以下上下文提供程序设置。

```yaml
context:
  - provider: krugleknow
```

### 代码库检索

询问有关你代码库的问题。

![](codebase_retrieval.gif)

KLiP 会为你的本地代码库建立索引，使其能够自动从整个工作区中提取最相关的上下文。这是通过基于嵌入的检索和关键词搜索的组合实现的。默认情况下，所有嵌入都在本地计算和存储。

代码库检索功能目前通过"codebase"和"folder"上下文提供程序提供。你可以在输入框中输入 `@codebase` 或 `@folder` 然后提问。输入将与代码库（或文件夹）其余部分的嵌入进行比较，以识别相关文件。

**常见用例：**

- **关于代码库的高级问题**
  - "我们在哪里使用了 Spring 安全功能？"
  - "如何向服务器添加新的端点？"
  - "是否有现有代码可以将 XML 转换为 JSON？"

- **使用现有示例作为参考生成代码**
  - "按照 `xyz` 的其他子类中看到的模式，实现 `foo` 类中的 `bar` 方法。"
  - "使用 Python 的 argparse 为这个项目编写一个 CLI 应用的草稿。"
  - "使用与现有组件相同的模式，生成一个带有下拉列表的新 Vue.js 组件。"

- **使用 `@folder` 进行特定文件夹查询**
  - "这个文件夹的主要用途是什么？"
  - "我们如何使用 Krugle 的文件搜索 API？"
  - 上述任何示例，但使用 `@folder` 而不是 `@codebase`。

**何时不适用：**

- **当大型语言模型需要访问你代码库中的每个文件时** - 考虑使用 KrugleAI Web
  - "找出所有调用 `foo` 函数的地方。"
  - "审查我们的代码库并找出任何拼写错误。"

- **重构**
  - "向 `bar` 函数添加一个新参数并更新其用法。"

### 与你的文档聊天

`@docs` 上下文提供程序允许你直接在 KLiP 中与你的文档互动。此功能使你能够索引任何静态站点或 GitHub markdown 页面，使你在编码时更容易访问和利用你的文档。

![](docs.gif)

`@docs` 上下文提供程序通过爬取指定的文档站点，生成嵌入，并在本地存储它们来工作。这个过程允许快速高效地访问你的文档内容。

我们还为流行的框架和库提供了一些预索引的文档站点。你可以从 `@docs` 上下文提供程序的下拉列表中找到它们。

要添加你自己的文档，请[点击此处](#documentation)阅读更多内容。

![](docs_add.gif)

### 智能体编码体验

> 警告：🚧 这是一个实验性功能

代理通过工具增强聊天模型，以处理各种编码任务，允许它做出决策，并让你不必手动搜索上下文或执行操作。你可以在聊天模型角色设置中启用或禁用代理模式（工具使用）。

![](agent.gif)

![](agent2.gif)

### 支持所有 MCP 工具

[模型上下文协议（MCP）](https://modelcontextprotocol.io/introduction)是 Anthropic 提出的一个标准，用于统一提示、上下文和工具使用。KLiP 通过 [MCP 设置](#mcpservers)与任何 MCP 服务器兼容。

![](mcp.gif)

### 自定义你的提示

提示是可在聊天时随时引用且易于与团队共享的可重用指令和标准化模式。它们对于重复性或复杂任务特别有帮助。

![](prompt_customization.gif)

#### 快速入门 (Quickstart)

以下是设置提示文件来审查源代码的快速示例：

1. 在工作区顶层创建一个名为 `.klip/prompts/` 的文件夹。
2. 向此文件夹添加一个名为 `code-reivew.prompt` 的文件。文件名将作为你用于生成提示的斜杠命令的名称。
3. 在 `code-reivew.prompt` 中写入以下内容并保存：

```text
name: 代码审查
description: 代码审查
---

请仔细分析提供的代码并进行全面的代码审查。请特别注意以下方面并提供详细分析和改进建议：
  - 语法错误：检查语法问题、类型不匹配或未定义变量
  - 逻辑缺陷：识别潜在的逻辑缺陷、不当的边界条件处理、无限循环或性能瓶颈
  - 安全漏洞：检测 SQL 注入、XSS 攻击、CSRF 漏洞、未验证的用户输入和其他安全风险
  - 代码质量：评估代码可读性、模块化、命名约定和注释完整性
  - 最佳实践：指出不符合行业最佳实践的区域并提供改进建议

请按严重性顺序列出发现的问题，并为每个问题提供具体解决方案。

@open
```

4. 重新加载 VSCode

要使用此提示，打开你想要审查的源代码文件。在 KLiP 聊天框中，输入"@prompts"并选择"代码审查"提示。按 Enter 键，KLiP 将根据你预定义的提示生成响应。

#### 格式

一个 .prompt 文件由两部分组成

1. YAML 配置（在"---"上方）：设置"temperature"和"description"等参数。
2. 提示正文（在"---"下方）：实际的提示内容

##### YAML 配置

"YAML 配置"是 `---` 分隔符上方的所有内容，允许你指定模型参数。它使用 YAML 语法，目前支持以下参数：

- `name` - 显示标题
- `description` - 你在下拉列表中将看到的描述
- `version` - 可以是"1"（用于旧版提示文件）或"2"（这是默认值，不需要设置）

如果你不需要这些参数中的任何一个，可以省略 YAML 配置和 `---` 分隔符。

##### 提示正文

在提示正文中，你可以引用：

1. 文件（绝对或相对路径，基于工作区根目录）：

   - @CHANGELOG.md
   - @src/app/main.py
   - @/Users/someone/Desktop/some-coderepo/src/app/main.py

1. URL：

   - @<https://some.site.com>

2. 上下文提供程序：
  
   - @main.py
   - @open
   - @tree
   - @skeleton
   - ...

### 历史记录

你可以在历史记录页面打开聊天历史记录，编辑聊天标题和删除聊天。

<img width="400" alt="历史记录" src="history.gif">

### 模型自定义

如果你有特定需求，例如从远程服务器添加单独的 KrugleAI 15B 模型，你可以在设置页面进行操作。

![](model_setup01.png)

KLiP 支持来自 Anthropic、DeepSeek 和 OpenAI 的模型，以及与 OpenAI API 协议兼容的任何其他模型。只需输入你的 API 密钥并在高级设置中设置 API 基础 URL。

![](model_setup02.png)

### 仪表盘

仪表盘允许你查看词元使用状态等信息。

![](dashboard.png)

---

## 快速设置

1. 按照[此处](../Shasta/deployment_guide_zh.md)提供的部署指南安装 Shasta，以及[此处](./deployment_guide_zh.md)安装 KLiP。

2. 安装后，你会注意到 KLiP 徽标出现在左侧边栏中。点击它将打开 KLiP 扩展。

<img width="400" alt="快速启动" src="quick_start.png">

我们强烈建议将 KLiP 移至 VS Code 的右侧边栏。这确保在使用 KLiP 时文件资源管理器保持可访问状态，并且可以使用键盘快捷键（`cmd/ctrl + option/alt + B`）轻松切换侧边栏。

![](dnd.gif)

3. 当你首次安装并打开 KLiP 时，你将看到一个设置向导。

第 1 步：配置 KrugleKnow。输入 KrugleKnow API URL。如果在你的 KrugleKnow 服务器上启用了身份验证，请提供用户名和密码。否则，将这些字段留空。

<img width="500" src="install_klip3.png">

第 2 步：配置 Shasta/Shasta Pro 设置。如果你已经升级到 0.7.0 及以上版本并完成了模型配置，这一步就不会出现。

<img width="500" src="install_klip4.png">

设置向导完成后，VSCode 将重新启动。

<img width="500" src="install_klip5.png">

4. 现在你可以断开互联网连接，利用 KLiP 进行 AI 代码开发。

---

## 如何使用KLiP

### 简介

在编程过程中适当地集成大型语言模型(LLM)可以提高效率。本指南概述了我们推荐使用KLiP的场景以及可能不适合使用的情况。

KLiP的有效性取决于底层的KrugleAI代码LLM，它用于生成编辑和解释。请记住，LLM有时可能会生成不准确的建议，比如引入不存在的库或语法。如果您遇到看起来不对的建议，建议查阅相关文档进行核对。

随着KLiP的使用，您会逐渐了解何时可以信任KLiP的建议。通过实验来熟悉它是个好方法，这样可以了解什么会产生理想的结果。KLiP会提示您接受或拒绝它提出的任何更改，并在需要时提供撤销修改的灵活性。

如果您不确定KLiP是否能够帮助完成特定任务，请考虑以下步骤：

'选择'指的是在文件中选择一段文本，并按下`cmd + L`(macOS)或`ctrl + L`(Windows)将其包含在KLiP聊天消息中。

- **选择**：使用`cmd/crtl + L`选择您希望更好理解的代码部分，并在输入框中输入"告诉我这段代码是如何工作的"。
- **评估**：如果解释看起来合理，在仍然选择代码部分的情况下，询问"你会如何更改这段代码来：**[您的任务]**"？
- **修改**：如果解释符合您的期望，您可以点击`应用`按钮应用代码。或者，继续选择代码片段，按下`cmd/crtl + I`启动修改命令，并输入**[您的任务]**直接内联修改代码。
- **迭代方法**：如果初次尝试没有产生期望的结果，使用`cmd/ctrl + shift + backspace`拒绝更改并重试，因为KLiP每次尝试可能会提供不同的建议。
- **澄清**：如果KLiP没有提供期望的结果，优化您的提示并提供更具体的指令，清晰地表达您的期望。
- **分解**：如果以上都失败了，考虑将任务分解为更小的子任务，并在KLiP的帮助下或手动解决它们。

请记住，无论是由您自己编写还是由您指导的LLM编写，所有代码的责任都在于您。因此，审查LLM生成的输出至关重要。为了简化这一过程，KLiP图形界面提供了LLM所采取行动的自然语言描述。

### 何时使用KLiP

KLiP在各种场景中都非常有价值，可以帮助您高效完成任务：

#### 简化复杂编辑

KLiP在传统查找和替换方法不足的情况下特别有效，例如执行内联编辑`cmd/crtl + I`"将所有这些更改为那样。"

**示例**

- `cmd/crtl + I`"在此位置将竖线替换为'Union'"
- `cmd/crtl + I`"通过使用更具描述性的变量名来提高这里的可读性"

#### 从头开始编写文件

KLiP简化了启动各种类型文件的过程，包括React组件、Python脚本、Shell脚本、Makefiles、单元测试等。

**示例**

- `cmd/crtl + I`"起草一个Python脚本以获取《纽约时报》的最新新闻"
- `cmd/crtl + I`"集成一个用于语法高亮代码的React组件"

#### 从头开始创建样板代码

KLiP进一步扩展其功能，协助创建样板结构。例如，它可以帮助构建Python包的框架，包括一个用于排序参数并显示它们的typer CLI应用程序。

**示例**

- `cmd/crtl + I`"利用此架构生成SQL查询以检索最近流失的用户"
- `cmd/crtl + I`"开发一个shell脚本将我的主目录备份到/tmp/"

#### 修复选定的代码

选择代码部分后，使用KLiP进行改进（例如，`cmd/crtl + I`"修改函数以这种方式运行"或`cmd/crtl + I`"在所有地方实现这一点"）。

**示例**

- `cmd/crtl + I`"调整这个Digital Ocean Terraform文件使其与GCP一起工作"
- `cmd/crtl + I`"将此函数重写为异步"

#### 询问选定的代码或整个文件

如果对某些代码的工作方式不确定，请选择它并询问"这段代码是如何工作的？"

**示例**

- "我应该在页面的哪个部分向后端发出这个请求？"
- "我如何实现这些iframe之间的通信？"

#### 解决错误

KLiP可以帮助解释错误/异常并建议潜在的解决方案。在终端遇到错误/异常时，按下`cmd + shift + R`（macOS）/`ctrl + shift + R`（Windows）。这将把堆栈跟踪发送到KLiP并提示对问题的解释。

#### 确定适当的Shell命令

您可以询问诸如"如何识别端口8000上运行的进程？"之类的问题，而不必转移焦点和分散注意力。

**示例**

- "load_dotenv库的名称是什么？"
- "如何识别端口8000上运行的进程？"

#### 提出单轮开放式问题

您可以提出不期望转变为多轮对话的开放式问题，而不必离开IDE。

**示例**

- "如何设置Prisma架构以级联删除？"
- "密集嵌入和稀疏嵌入之间有什么区别？"

#### 编辑小型现有文件

您可以选择整个文件并请求KLiP对其进行增强，只要文件不太大。

**示例**

- `cmd/crtl + I`"这是一个PostgreSQL连接器，现在创建一个Kafka连接器"
- `cmd/crtl + I`"修改这个API调用以检索所有页面"

#### 利用多个文件的上下文

与手动修改类似，一次专注于一个文件。但是，如果其他文件包含相关信息，也选择这些代码段作为额外的上下文。

#### 执行少步骤的任务

Klip可以协助完成更多任务，通常是那些完成时不需要太多步骤的任务。

**示例**

- `cmd/crtl + I`"生成一个IAM策略，为用户创建对S3的只读访问权限"
- `cmd/crtl + I`"在这个仪表板组件中将这个图变成条形图"

### 何时不使用KLiP

以下是目前KLiP可能**没**有帮助的场景：

#### 深入调试

如果您正在深入调试一个涉及多个文件且已持续约20分钟的复杂问题，KLiP可能尚无法帮助您连接所有点。但是，分享您的进展并寻求建议可以促使KLiP提供潜在解决方案的想法。

#### 并行编辑多个文件

目前，KLiP一次只能处理一个文件中的编辑。但是，在确定必要的更改后，您可以指导KLiP帮助您依次修改多个文件。

#### 使用整个文件上下文

对于非常大的文件，由于LLM上下文窗口有限，KLiP可能难以包含全部内容。考虑选择包含相关上下文的特定代码部分，因为很少需要完整的文件。

#### 编辑大文件

同样，尝试一次编辑太多行可能会超出上下文窗口限制，并在应用建议时导致性能缓慢。

#### 选择非常长的行

选择过长的行（例如复杂的SVG）可能会遇到与上述类似的问题。

#### 具有众多步骤的任务

虽然KLiP可能无法一次全面处理任务，但将它们分解为子任务通常可以让KLiP帮助完成每个步骤。

---

## 设置

点击右下角的齿轮图标以自定义KLiP设置。

<img width="360" alt="image" src="config.png">

<img width="360" alt="image" src="config2.png">

### 模型

您可以在模型部分添加新模型或管理模型角色。

#### 聊天

<img width="500" alt="image" src="settings_chat.png">

"聊天模型"是一种设计用于以对话格式回应的大语言模型。为了处理一般问题并生成复杂代码，最佳的聊天模型通常非常大——通常拥有超过405亿参数——或者是像Krugle代码LLM这样的专业代码模型，它们经过针对特定用例的训练和微调。

在KLiP中，这些模型用于标准聊天和VS Code操作。如果没有为编辑或应用功能定义特定模型，则选定的聊天模型也将处理这些任务。

配置文件config.yaml中的示例：

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

#### 智能体模式

智能助手为聊天模型增加了工具支持，能够处理各种编程任务，自主做出决策，让您无需手动搜索上下文或执行操作。您可以在聊天模型角色设置中启用或禁用智能助手模式（工具使用）。

智能助手在与聊天相同的界面中运行，您可以继续使用相同的输入框发送消息。提供上下文的手动方法—例如标记@[上下文提供者](#context-providers)或从编辑器中选择代码—仍然有效。目前支持智能助手模式的模型包括：Krugle Code 15B/35B、OpenAI GPT-4o、o1、o1-mini、o3、o3-mini以及Anthropic Claude 3.5/3.7 Sonet。

使用智能助手，您可以用自然语言给出指令并让模型处理任务。例如，您可以说：

将此项目中所有eslint配置的`react/no-unescaped-entities`规则设置为"off"。

智能助手将确定完成任务所需的适当工具。

默认情况下，智能助手在使用工具前会征求您的许可。点击"允许"继续或"取消"拒绝该操作。

<img width="500" alt="image" src="settings_agent2.png">

<img width="500" alt="image" src="settings_agent3.png">

您可以通过选择以下选项之一来配置智能助手如何使用每种工具：

- **Allowed (允许)**（默认）：向用户请求许可，显示"取消"和"允许"按钮。
- **Automatic (自动)**：跳过许可请求；工具自动调用，其响应直接发送给模型。
- **Disabled (禁用)**：该工具不对模型开放使用。

<img width="500" alt="image" src="settings_agent.png">

##### 显示相关问题

<img width="800" alt="image" src="settings_related.png">

启用/禁用相关问题功能。

#### 自动补全

<img width="500" alt="image" src="settings_autocomplete.png">

"自动补全模型"是一种使用特殊格式训练的大语言模型，称为填充中间内容（FIM）。这种格式提供代码片段的开头（前缀）和结尾（后缀），模型预测中间缺失的部分。由于任务范围明确，即使只有30亿参数的较小模型也能表现良好。相比之下，即使经过大量提示，较大的聊天模型通常在此任务上表现不佳。

在KLiP中，自动补全模型用于在您输入时提供内联代码建议。要启用此功能，模型的角色必须在config.yaml文件中包含"autocomplete"。

config.yaml文件示例：

```yaml
- name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - autocomplete
```

更多选项：

- 使用自动补全缓存 – 启用或禁用自动补全缓存。
- 多行自动补全 – 控制自动补全是否支持多行。选项为`always`（始终）、`never`（从不）或`auto`（自动，默认）。
- 在文件中禁用自动补全 – 用逗号分隔的glob模式列表，用于在匹配的文件中禁用自动补全（例如，"_/.md, */.conf"）。

##### 代码自动补全开关

要启用/禁用KLiP代码自动补全功能，只需点击VSCode状态栏中的KLiP按钮。然后在下拉菜单中切换"启用自动补全"或"禁用自动补全"。

![](autocomplete.png)

#### 编辑

为编辑提示使用与聊天提示不同的模型通常更有益，因为编辑任务通常更专注于代码，且对会话流畅性要求较低。因此，推荐使用Krugle Code 15B/35B等代码专用大语言模型。

在KLiP中，您可以将"edit"角色分配给模型，表明它应处理编辑请求。如果未定义特定的编辑模型，系统将默认使用所选的聊天模型。

config.yaml文件示例：

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

#### 应用更改

在编辑代码时，聊天和编辑模型的输出通常与现有代码不能很好地对齐。带有"apply"角色的模型用于生成更准确的差异，以便将更改应用到文件中。

以下是来自config.yaml文件的示例：

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

#### 嵌入

嵌入模型旨在将文本片段转换为向量，从而可以快速与其他向量进行比较以确定文本相似度。这些模型通常比大型语言模型更小、更快且更经济高效。

在KLiP中，嵌入在索引过程中生成，并被`@Codebase`或`@docs`上下文提供器用来在本地代码库或文档中执行相似度或语义搜索。KLiP提供两种嵌入选项：

- **transformers.js** – 一个集成到VS Code扩展中的内置嵌入模型。
- **shasta** – 由Shasta提供支持的高级嵌入模型。例如：

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

### 代码库索引

<img width="500" alt="image" src="settings_codebase.png">

您可以启用或禁用代码库索引，检查索引状态，并触发重新索引。

### 文档

<img width="500" alt="image" src="settings_docs.png">

您可以添加或移除文档索引，检查索引状态，并触发重新索引。默认情况下，KLiP使用轻量级工具来爬取不需要JavaScript渲染的文档网站。

如果您需要爬取动态生成的网站，或者遇到错误，可以启用"使用Chromium进行文档爬取"选项。这将在KLiP缓存目录中下载并安装Chromium。

一旦网站被索引，从聊天框中输入`@docs`，从下拉菜单中选择您的文档，KLiP将自动使用相似度搜索为您的查询找到相关部分。

<img width="500" alt="image" src="docs2.png">

![](docs3.png)

点击使用的上下文将显示源文档。

<img width="1065" alt="image" src="docs4.png">

KLiP还预先索引了许多常用的文档网站。这些网站的嵌入由我们托管，并在首次请求后下载到本地。所有其他索引完全在本地进行。请确保在您的防火墙中将域名`krugle-klip.s3.ap-northeast-1.amazonaws.com`列入白名单。

### 外观

<img width="500" alt="image" src="settings_appearance.png">

- **显示会话标签**：启用后，在聊天上方显示标签，帮助组织和访问会话。默认禁用。
- **代码块自动换行**：启用后，允许文本在代码块内自动换行。默认禁用。
- **显示聊天滚动条**：启用后，在聊天窗口中显示滚动条。默认禁用。
- **禁用会话标题生成**：禁用时，在第一条消息后使用当前聊天模型自动为每个聊天会话生成摘要标题。默认禁用。
- **显示原始Markdown**：启用后，显示原始Markdown文本响应。默认禁用。

---

## YAML 配置文件

你可以手动构建或编辑你的 config.yaml 文件，通过点击 KLiP 设置页面顶部的 `Open Settings (YAML)` 链接来访问。

<img width="300" alt="image" src="config3.png">

### models

models 部分定义了你设置中使用的语言模型。这些模型用于聊天、编辑和嵌入等功能。

**属性：**

- `name` (**必填**)：配置中模型的唯一标识符。
- `provider` (**必填**)：模型提供商（例如 `openai`、`shasta`、`anthropic`）。
- `model` (**必填**)：具体的模型名称（例如 `gpt-4o`、`krugle-code-15b-chat`）。
- `apiBase`：可选。覆盖为模型定义的默认 API 基础 URL。
- `roles`：定义模型可以执行的角色的数组，如 `chat`、`autocomplete`、`embed`、`edit`、`apply`。默认值：`[chat, edit, apply]`。
- `capabilities`：表示模型能力的字符串数组，覆盖 KLiP 的自动检测。支持的值包括 `tool_use` 和 `image_input`。
- `systemMessage`：在**聊天**模式下覆盖默认的系统提示。
- `defaultCompletionOptions`：模型补全的默认设置：
  - `contextLength`：最大上下文大小（以 token 为单位）。
  - `maxTokens`：此参数设置模型在单次推理请求中可以生成的最大 token 数量。它有助于控制生成文本的长度，防止模型生成过长的响应。在上面的例子中，最大 token 数设置为 2048。
  - `temperature`：此参数控制生成文本的随机性。较低的温度值使模型更保守和确定性，产生更可预测的输出。另一方面，较高的温度值增加随机性，导致更多样化但可能不太连贯的输出。在上面的例子中，温度设置为 1，这是一个中性设置；`0.0` 是确定性的，`1.0` 是高度随机的。
  - `topP`：也称为核采样，此参数基于 token 的累积概率质量动态调整考虑的 token 数量。它允许模型生成多样化的输出，同时确保生成 token 的总概率质量保持在一定阈值（由 topP 指定）以上。在上面的例子中，topP 设置为 0.75，意味着模型考虑 token 直到累积概率质量超过 75%。
  - `topK`：此参数限制生成过程中每一步考虑的 token 数量。它限制模型只考虑根据概率分布最有可能的前 k 个 token。这有助于防止模型生成不可能或无意义的 token。在上面的例子中，topK 设置为 45，意味着在每一步只考虑概率最高的前 45 个 token。
  - `stop`：结束生成的停止序列数组。
  - `n`：要生成的补全数量。
  - `reasoning`：布尔值，用于为 Anthropic Claude 3.7+ 模型启用推理模式。
  - `reasoningBudgetTokens`：Anthropic Claude 3.7+ 模型中推理的 token 预算。
- `embedOptions`：当模型具有 `embed` 角色时适用。用于嵌入操作：
  - `maxChunkSize`：每个文档块的最大 token 数（最小值：128）。
  - `maxBatchSize`：每个请求的最大块数（最小值：1）。

示例：

```yaml
models:
  # ...
  # Krugle LLM example
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
  # Autocomplete example
  - name: Autocomplete Model
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - autocomplete

  # OpenAI compatible LLM example
   - name: My LLM
    provider: openai
    apiBase: http://localhost:8081/v1
    model: some-model
    capabilities:
      - tool_use
    roles:
      - chat
      - edit
  # Anthropic reasoning example
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

### 上下文

`context` 部分指定了上下文提供者，它们向大语言模型（LLMs）提供额外信息。每个提供者都可以通过特定参数进行自定义。

有关每个上下文提供者的详细用法和参数信息，请参阅[上下文提供者](#context-providers)章节。

**属性：**

- `provider`（**必填**）：上下文提供者的标识符或名称（例如，`code`、`docs`、`web`）
- `name`：提供者的可选自定义名称
- `params`：可选设置，用于配置提供者的行为。

示例：

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

Rules（规则）为 Chat、Edit 和 Agent 请求提供模型指令。通常不用于其他请求类型，如自动补全 (Autocomplete)或应用更改 (Apply)。

规则区块是一个数组，每个元素可以是简单的文本字符串。

示例：

```yaml
rules:
  - Please keep answers concise. Avoid explaining obvious concepts. You can assume I'm familiar with most programming topics.
```

#### .kliprules

您还可以通过在项目根目录添加 .kliprules 文件来定义特定项目的规则。这个纯文本文件的全部内容将覆盖 config.yaml 中设置的任何规则。

示例：

```.kliprules
Please keep answers concise. Avoid explaining obvious concepts. You can assume I'm familiar with most programming topics.
```

### prompts

自定义提示列表，可以在聊天窗口中使用 `/提示名称` 触发。每个提示包括名称、描述和提示文本本身。

示例：

```yaml
prompts:
  - name: inspect
    description: 代码质量和安全检查
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
```

在聊天窗口中使用 `/inspect` 命令来激活此提示。

### docs

要索引的文档站点列表。

**属性：**

- `name`（**必填**）：文档站点的名称，显示在 `@docs` 下拉菜单和其他 UI 元素中。
- `startUrl`（**必填**）：爬取的起始页面——通常是文档的根页面或介绍页面。
- `maxDepth`：爬取过程中要跟踪的链接最大深度。默认值为 `4`。
- `favicon`：站点的图标 URL。默认为相对于 `startUrl` 的 `/favicon.ico`。
- `useLocalCrawling`：绕过默认爬虫，仅使用本地爬虫。

示例：

```yaml
docs:
  - name: Krugle
    startUrl: https://krugle.co.jp
    favicon: ""
```

保存文件后将开始索引。

### mcpServers

[模型上下文协议](https://modelcontextprotocol.io/introduction)（Model Context Protocol）是 Anthropic 提出的标准，用于统一提示、上下文和工具使用。KLiP 兼容任何 MCP 服务器。

**属性：**

- `name`（**必填**）：MCP 服务器的名称。
- `command`（**必填**）：用于启动服务器的命令。
- `args`：可选。命令的参数数组。
- `env`：可选。服务器进程的环境变量映射。
- `connectionTimeout`：可选。服务器连接超时时间（毫秒）。

示例：

```yaml
mcpServers:
  - name: Time
    command: uvx
    args:
      - mcp-server-time
      - --local-timezone
      - Asia/Tokyo
```

### 完整的 YAML Config 示例

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

## 上下文提供器

上下文提供器使您可以简单地输入'@'并访问一个下拉菜单，其中包含可以作为语言模型(LLM)上下文的内容。每个上下文提供器都作为一个插件运行。如果您需要引用一个不可用的信息源，您可以向Krugle支持团队请求新的上下文提供器。

例如，假设您正在处理一个新的GitHub Issue。您输入`@issue`并选择相关的issue。现在，KLiP可以访问issue标题和内容。如果您知道issue与'readme.md'和'foobar.py'等文件相关，您可以输入`@readme`和`@foobar`来定位并选择它们。因此，这三个"上下文项"与您其余的输入无缝集成。

<img width="449" alt="image" src="context.png">

要使用任何内置的上下文提供器，请导航到config.yaml并将它们包含在contextProviders列表中。

### 文件

输入`@file`引用当前工作区中的任何文件。

```yaml
context:
  - provider: file
```

### 打开的文件

使用`@open`访问所有打开文件的内容。将`onlyPinned`设置为`true`只引用已固定的文件。

```yaml
context:
  - provider: open
    params:
      onlyPinned: true
```

### 当前文件

使用`@currentFile`访问您正在编辑/查看的当前文件内容。

```yaml
context:
  - provider: currentFile
```

### 代码

使用`@code`引用项目中特定的函数或类。

```yaml
context:
  - provider: code
```

### Git差异

使用`@diff`引用当前分支中的所有更改。这有助于在提交前总结您的工作或请求一般性审查。

![](diff.png)

```yaml
context:
  - provider: diff
```

### Git提交

使用`@commit`引用特定Git提交的元数据、差异或所有最近的提交。

```yaml
context:
  - provider: commit
    params:
      Depth: 50
      LastXCommitsDepth: 10
```

深度指定加载到子菜单中的提交数量，默认为50。LastXCommitsDepth决定包含的最近提交数量，默认为10。

### 代码库

使用`@codebase`自动检索代码库中最相关的代码片段。

```yaml
context:
  - provider: codebase
```

**配置**

您可以通过多个选项配置代码库上下文提供器的行为。这些设置适用于`@codebase`和`@folder`上下文提供器，可以在`config.yaml`中调整：

**文件位置：** `~/.klip/config.yaml`

```yaml
context:
  - provider: codebase
      params:
        nFinal: 5
        nRetrieve: 25
        useReranking: true
```

- **`nRetrieve`：** 从向量数据库初始检索的结果数量（默认：25）。
  
- **`nFinal`：** 重新排序后使用的最终结果数量（默认：5）。

- **`useReranking`：** 是否使用重新排序，初始选择`nRetrieve`个结果，然后使用LLM选择顶部`nFinal`个结果（默认：true）。

**索引过程中忽略文件**

KLiP尊重`.gitignore`文件来决定哪些文件不应被索引。要排除额外的文件，您可以创建一个`.klipignore`文件，它遵循与`.gitignore`相同的规则。

要强制刷新索引，请按下`cmd/ctrl + shift + P`重新加载VS Code窗口，然后选择"重新加载窗口"。

### 文件夹

输入`@folder`使用与`@codebase`相同的检索机制，但仅限于单个文件夹。

```yaml
context:
  - provider: folder
```

### 通过正则表达式模式在工作区内进行精确搜索

输入`@search`引用代码库搜索的结果，类似于您在VS Code中搜索获得的结果。

> 注意：由于此上下文提供器的数据大小可能很大，在没有GPU加速的情况下本地部署Shasta可能会导致性能缓慢。因此，建议在GPU上本地部署Shasta或使用在GPU实例上远程部署的KrugleAI Base Pro服务，以获得更快的推理速度和改进的性能。

```yaml
context:
  - provider: search
```

### 文件树

输入`@tree`引用当前工作区的层次结构。这将允许LLM查看项目的嵌套目录布局。

> 注意：由于此上下文提供器的数据大小可能很大，在没有GPU加速的情况下本地部署Shasta可能会导致性能缓慢。因此，建议在GPU上本地部署Shasta或使用在GPU实例上远程部署的KrugleAI Base Pro服务，以获得更快的推理速度和改进的性能。

```yaml
context:
  - provider: tree
```

### URL

输入`@url`并输入一个URL。KLiP将把它转换为LLM的Markdown文档。

```yaml
context:
  - provider: url
```

### 开发文档

要索引和检索任何文档站点的片段，请输入`@docs`。

```yaml
context:
  - provider: docs
```

### 剪贴板

引用剪贴板项目

```yaml
context:
  - provider: clipboard
```

### 终端

使用`@terminal`访问IDE终端的内容。

```yaml
context:
  - provider: terminal
```

### GitHub Issues

输入`@issue`直接引用GitHub issues中的对话。确保包含您自己的[GitHub个人访问令牌](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token)以避免速率限制：

```yaml
context:
  - provider: issue
    params:
      repos:
        - owner: krugle2
          repo: klip
      githubToken: ghp_xxxxxxxxxxxxxx
```

### GitLab合并请求

输入`@gitlab-mr`引用GitLab上当前分支的开放合并请求(MR)。

**配置**

创建具有`read_api`范围的[个人访问令牌](https://docs.gitlab.com/ee/user/profile/personal_access_tokens.html)，然后将以下内容添加到您的配置中：

```yaml
context:
  - provider: gitlab-mr
    params:
      token: "xxxxxxxxxxxxxxxxxxxx"
```

**使用自托管GitLab**

要与自托管GitLab实例通信，请在配置中设置`domain`参数。默认情况下，这设置为`gitlab.com`。

```yaml
context:
  - provider: gitlab-mr
    params:
      token: "xxxxxxxxxxxxxxxxxxxx"
      domain: "gitlab.example.com"
```

**过滤评论**

如果您正在编辑特定代码，可以通过将`filterComments`设置为`true`来过滤掉其他文件的评论。

### Jira Issues

输入`@jira`引用Jira issue中的对话。确保包含您自己的[Atlassian API令牌](https://id.atlassian.com/manage-profile/security/api-tokens)，或使用您的`email`和`token`，将令牌设置为基本身份验证的密码。如果您使用自己的Atlassian API令牌，请不要配置您的电子邮件。

```yaml
context:
  - provider: jira
    params:
      domain: company.atlassian.net
      token: ATATT...
```

**Jira数据中心支持**

此上下文提供器支持Jira API版本2和3。默认情况下，它使用版本3（云版本），但如果您使用的是Jira数据中心版本，您需要使用`apiVersion`属性将API版本设置为2。

```yaml
context:
  - provider: jira
    params:
      apiVersion: "2"
```

**Issue查询**

默认情况下，使用以下查询查找issues：

```sql
assignee = currentUser() AND resolution = Unresolved order by updated DESC
```

您可以通过设置`issueQuery`参数覆盖此查询。

### 操作系统

输入`@os`引用当前操作系统的架构和平台。

```yaml
context:
  - provider: os
```

### 代码库骨架

提供代码库或子文件夹中所有文件的概览，突出显示每个文件中顶级类、函数和方法的关键符号。它包括定义这些符号的关键代码行，帮助模型更好地理解每段代码如何与整个代码库连接。

```yaml
context:
  - provider: skeleton
```

### 问题

引用当前文件中的问题。

```yaml
context:
  - provider: problems
```

### KrugleKnow

这是启用KrugleKnow搜索功能所必需的。

```yaml
context:
  - provider: krugleknow
```

### PostgreSQL - 工作进行中，即将推出

要引用表的架构以及示例行，请输入`@postgres`。

### 数据库表 - 工作进行中，即将推出

输入`@database`引用表架构。您可以使用下拉菜单或根据配置开始输入表名。

### 网络搜索

一旦启用代理模式，KLiP可以使用最新的互联网数据提供更准确和最新的答案。

在您的config.yaml中，添加`web`上下文提供器，如下例所示。您可以在[serper.dev](https://serper.dev/)获取免费API密钥。

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

### 调试器：局部变量

输入`@debugger`引用该线程调用栈顶部n层（默认为3）内的局部变量。

```yaml
context:
  - provider: debugger
    params:
      stackDepth: 3
```

### 请求上下文提供器

如果您找不到所需的内容，请联系Krugle支持团队或在[此处](https://github.com/krugle2/Klip/issues/new)创建issue来请求新的上下文提供器。

---

## 常见问题

### 为什么KLiP持续输出乱码

请首先查看`shasta.log`文件。在macOS或Windows上，您可以在`$SHASTA_HOME/shasta.log`找到它。而在Linux上，位置是`/var/log/shasta/shasta.log`。如果您遇到以下列出的错误，表明您的机器内存不足。

```log
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
```

**解决方案：**

调整KLiP配置文件config.yaml中的`contextLength`和`maxTokens`参数。以下是一些示例值对：`16384/4096`、`8192/4096`、`8192/2048`、`4096/2048`、`2048/1024`、`2048/512`、`1024/512`。

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

### 如何自定义索引哪些文件？

Klip遵循`.gitignore`文件的规则来确定哪些文件不应被索引。要排除额外的文件，您可以将它们添加到`.klipignore`文件中，该文件遵循与`.gitignore`相同的规则。

例如，您可以在项目的顶层添加一个`.klipignore`文件。

```shell
.vscode/
node_modules/
dist
media
.git
*.log

# 在此处添加您的其他规则
# ...
```

### 为什么Shasta不总是使用所有CPU核心？

只需添加`numThreads`选项即可。

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

### 为什么Shasta不总是使用GPU？

Shasta使用专用GPU（NVIDIA/AMD）显存进行推理。CPU始终是必需的，因为像加载模型参数这样的任务仍然需要将模型文件读入RAM，然后再传输到显存中。

#### 100% GPU使用率

```text
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

所有模型权重都加载到显存中。下一个因素是上下文窗口大小。

如果有足够的可用显存来处理上下文窗口大小，将使用GPU。如果没有，CPU将处理推理。

可以在客户端（AI Web或KLiP）调整上下文窗口大小。例如，您可以通过修改`config.yaml`来减少KLiP中的`contextLength`：

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

#### 部分CPU/GPU使用

当显存几乎满或完全满时，模型的剩余部分将加载到系统内存中，并且CPU将无限期地处理推理。然而，GPU仍然比单独使用CPU更快、更高效。

```shell
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

虽然GPU使用率为100%，但显存例如只剩下500 MB可用。

或者

```shell
krugle-code-10b:latest c1669e6bec24 10 GB 46%/54% CPU/GPU
```

### 我没有看到任何代码补全

请按照以下步骤确保一切设置正确：

1. 确保"Enable Tab Autocomplete"设置已勾选（在VS Code中，通过点击状态栏中的"Klip"按钮切换它）。
2. 验证Shasta已安装、设置并正在运行。
3. 运行`shasta ls`确认模型已下载。
4. 禁用任何其他补全提供程序，因为它们可能会干扰。
5. 避免同时使用KLiP进行聊天，因为这会导致Shasta反复加载和卸载内存中的模型，导致两者的响应缓慢或没有响应。
6. 检查日志输出以查找潜在错误（在VS Code中按`cmd/ctrl + shift + P` -> "Toggle Developer Tools" -> "Console"标签）。
7. 如果您仍然有问题，请告诉我们，我们将尽快提供帮助。

### 自动补全很慢

这取决于您的硬件。

### 自动补全不了解我的代码

我们正在努力提高这个系统的准确性，预计在未来几周内会有显著改进。

### 自动补全包含格式错误

如果您注意到一种重复出现的错误模式，请向我们报告。我们将尽快解决和修复它。

---

版权信息

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
