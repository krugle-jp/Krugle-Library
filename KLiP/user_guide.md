# KrugleAI KLiP User Guide

**Version**: v0.7.1-beta

<div align="center">
<img width="300" alt="KLiP" src="logo.png">
</div>

- [KrugleAI KLiP User Guide](#krugleai-klip-user-guide)
  - [Introduction](#introduction)
  - [Features](#features)
    - [Understand your code quickly and easily](#understand-your-code-quickly-and-easily)
    - [Add classes, files, and more into the context](#add-classes-files-and-more-into-the-context)
    - [Inline Editing](#inline-editing)
    - [AI-powered code autocompletion](#ai-powered-code-autocompletion)
    - [Reference your organization's code and documentation](#reference-your-organizations-code-and-documentation)
    - [Codebase Retrieval](#codebase-retrieval)
    - [Chat with your documentation](#chat-with-your-documentation)
    - [Agentic Coding Experience](#agentic-coding-experience)
    - [Supports all MCP tools](#supports-all-mcp-tools)
    - [Customize Your Own Prompts](#customize-your-own-prompts)
      - [Quick Start](#quick-start)
      - [Format](#format)
        - [YAML Configuration](#yaml-configuration)
        - [Prompt Body](#prompt-body)
    - [History](#history)
    - [Model Customization](#model-customization)
    - [Dashboard](#dashboard)
  - [Quickstart](#quickstart)
  - [How to use KLiP](#how-to-use-klip)
    - [TL;DR](#tldr)
    - [When to use KLiP](#when-to-use-klip)
      - [Simplifying Complex Edits](#simplifying-complex-edits)
      - [Writing files from scratch](#writing-files-from-scratch)
      - [Crafting Boilerplate from Scratch](#crafting-boilerplate-from-scratch)
      - [Fix selected code](#fix-selected-code)
      - [Asking About Selected Code or an Entire File](#asking-about-selected-code-or-an-entire-file)
      - [Addressing errors](#addressing-errors)
      - [Determining Appropriate Shell Commands](#determining-appropriate-shell-commands)
      - [Asking Single-Turn Open-Ended Questions](#asking-single-turn-open-ended-questions)
      - [Editing Small Existing Files](#editing-small-existing-files)
      - [Leveraging Context from Multiple Files](#leveraging-context-from-multiple-files)
      - [Executing Tasks with Few Steps](#executing-tasks-with-few-steps)
    - [When to not use KLiP](#when-to-not-use-klip)
      - [In-Depth Debugging](#in-depth-debugging)
      - [In Parallel Editing of Multiple Files](#in-parallel-editing-of-multiple-files)
      - [Using Entire File Context](#using-entire-file-context)
      - [Editing Large Files](#editing-large-files)
      - [Selecting Really Long Lines](#selecting-really-long-lines)
      - [Tasks with Numerous Steps](#tasks-with-numerous-steps)
  - [Settings](#settings)
    - [Models](#models)
      - [Chat](#chat)
        - [Agent Mode](#agent-mode)
        - [Display Related Questions](#display-related-questions)
      - [Autocomplete](#autocomplete)
        - [Code autocomplete toggle](#code-autocomplete-toggle)
      - [Edit](#edit)
      - [Apply](#apply)
      - [Embed](#embed)
    - [Codebase indexing](#codebase-indexing)
    - [Docs](#docs)
    - [Appearance](#appearance)
  - [YAML Settings File](#yaml-settings-file)
    - [models](#models-1)
    - [context](#context)
    - [rules](#rules)
      - [.kliprules](#kliprules)
    - [prompts](#prompts)
    - [docs](#docs-1)
    - [mcpServers](#mcpservers)
    - [Complete YAML Config Example](#complete-yaml-config-example)
  - [Context Providers](#context-providers)
    - [File](#file)
    - [Open Files](#open-files)
    - [Current File](#current-file)
    - [Code](#code)
    - [Git Diff](#git-diff)
    - [Git Commits](#git-commits)
    - [Codebase](#codebase)
    - [Folder](#folder)
    - [Exact search within workspace via RegExp pattern](#exact-search-within-workspace-via-regexp-pattern)
    - [File Tree](#file-tree)
    - [URL](#url)
    - [Documentation](#documentation)
    - [Clipboard](#clipboard)
    - [Terminal](#terminal)
    - [GitHub Issues](#github-issues)
    - [GitLab Merge Request](#gitlab-merge-request)
    - [Jira Issues](#jira-issues)
    - [Operating System](#operating-system)
    - [Codebase Skeleton](#codebase-skeleton)
    - [Problems](#problems)
    - [KrugleKnow](#krugleknow)
    - [PostgreSQL - Work in Progress, Coming Soon](#postgresql---work-in-progress-coming-soon)
    - [Database Tables - Work in Progress, Coming Soon](#database-tables---work-in-progress-coming-soon)
    - [Web Search](#web-search)
    - [Debugger: Local Variables](#debugger-local-variables)
    - [Requesting Context Providers](#requesting-context-providers)
  - [FAQ](#faq)
    - [Why KLiP keeps outputting garbled text](#why-klip-keeps-outputting-garbled-text)
    - [How can I customize which files are indexed?](#how-can-i-customize-which-files-are-indexed)
    - [Why doesn't Shasta always use all CPU cores?](#why-doesnt-shasta-always-use-all-cpu-cores)
    - [Why doesn't Shasta always use the GPU?](#why-doesnt-shasta-always-use-the-gpu)
      - [100% GPU Usage](#100-gpu-usage)
      - [Partial CPU/GPU Usage](#partial-cpugpu-usage)
    - [I'm not seeing any code completions](#im-not-seeing-any-code-completions)
    - [Autocompletions are slow](#autocompletions-are-slow)
    - [Autocompletions don't know about my code](#autocompletions-dont-know-about-my-code)
    - [Autocompletions contain formatting errors](#autocompletions-contain-formatting-errors)

## Introduction

KLiP is an enterprise code autopilot tool designed for software development, integrating the capabilities of KrugleAI into your IDE.

With KLiP, you can seamlessly incorporate generated answers into your codebase, leveraging KrugleAI's powerful code Language Model (LLM) directly within your IDE as you navigate your workflows.

Some examples of what you can achieve are:

- Utilize `cmd/ctrl + I` to generate boilerplate code from natural language.
- Select code, describe refactoring steps, and have changes instantly applied in your editor.
- Pose high-level questions about your codebase, with KLiP automatically identifying relevant files (alpha).
- Efficiently generate unit tests for any function or class.
- Pose quick questions for immediate answers without leaving your editor.
- Have your current changes reviewed for errors beyond the compiler's scope.
- Simply type ***@*** to reference various sources while communicating with the LLM. Additional context providers forthcoming, such as `@docs` for code language and framework documentation, `@krugle` for files or documentation indexed by the KrugleKnow platform, `@jira` for referencing issues from Jira, and more.
- We offer extensive configuration options to tailor the extension to your specific workflows.
- Utilize our local tab-autocomplete for inline suggestions and rapid boilerplate code writing (alpha).

## Features

### Understand your code quickly and easily

![](code_explanation.gif)

If you're ever confused by a piece of code, KLiP can break it down for you, providing a clear and concise explanation that speeds up debugging and comprehension.

Press `cmd + L` (Mac) or `ctrl + L` (Windows) to get insights into the code you're working on.

### Add classes, files, and more into the context

![](add_context.gif)

Copying and pasting context into the chat box can disrupt your workflow. KLiP allows you to add classes, files, and more to your current context, so you can access everything you need in one place. It also addresses issues with LLM knowledge cutoffs.

### Inline Editing

Refactor your code directly where you're working.

![](inline_edit_01.gif)

There are built-in inline editing tools available for your selected code.

![](inline_edit_02.gif)

### AI-powered code autocompletion

KLiP supports AI-powered code autocompletion. Easily get code suggestions by simply pressing Tab.

![](ai_code_autocomplete.gif)

![](ai_code_autocomplete_02.gif)

### Reference your organization's code and documentation

KrugleKnow is a central search engine that offers federated access to an organization's codebase, code artifacts, and technical documentation. It provides tools for flexible analysis and search capabilities, enabling users to identify critical code patterns, security vulnerabilities, and application issues in real-time. The platform is designed to enhance collaboration and efficiency within development teams by making technical information easily accessible and actionable at scale.

With KLiP, you can search and browse any code files or documentation indexed in the KrugleKnow platform without needing to clone, download, or index them locally.

![](ke_search.gif)

The following context provider setting is required in the `config.yaml` file.

```yaml
context:
  - provider: krugleknow
```

### Codebase Retrieval

Ask questions about your codebase.

![](codebase_retrieval.gif)

KLiP indexes your local codebase, enabling it to automatically pull in the most relevant context from across your workspace. This is achieved through a combination of embeddings-based retrieval and keyword search. By default, all embeddings are calculated and stored locally.

The codebase retrieval feature is currently available through the "codebase" and "folder" context providers. You can use them by typing `@codebase` or `@folder` in the input box and then asking a question. The input will be compared with embeddings from the rest of the codebase (or folder) to identify relevant files.

**Common Use Cases:**

- **High-Level Questions About Your Codebase**
  - "Do we use Spring security feature anywhere?"
  - "How do I add a new endpoint to the server?"
  - "Is there existing code to convert XML to JSON?"

- **Generate Code Using Existing Samples as Reference**
  - "Implement the `bar` method in the `foo` class, following the patterns seen in other subclasses of `xyz`."
  - "Write a draft of a CLI application for this project using Python's argparse."
  - "Generate a new Vue.js component with a dropdown list, using the same patterns as existing components."

- **Use `@folder` for Specific Folder Queries**
  - "What is the main purpose of this folder?"
  - "How do we use Krugle's file search API?"
  - Any of the above examples, but with `@folder` instead of `@codebase`.

**When It's Not Useful:**

- **When the LLM Needs to Access Every File in Your Codebase** - Consider to use KrugleAI Web
  - "Find everywhere the `foo` function is called."
  - "Review our codebase and find any spelling mistakes."

- **Refactoring**
  - "Add a new parameter to the `bar` function and update its usages."

### Chat with your documentation

The `@docs` context provider allows you to interact with your documentation directly within KLiP. This feature enables you to index any static site or GitHub markdown pages, making it easier to access and utilize your documentation while coding.

![](docs.gif)

The `@docs` context provider works by crawling specified documentation sites, generating embeddings, and storing them locally for you. This process allows for quick and efficient access to your documentation content.

We also offer a selection of pre-indexed documentation sites for popular frameworks and libraries. You can find them from the dropdown list of the `@docs` context provider.

To add your own documentations please read more [here](#documentation).

![](docs_add.gif)

### Agentic Coding Experience

> Warning: 🚧 This is an experimental feature

Agent enhances the Chat model with tools to handle a wide range of coding tasks, allowing it to make decisions and save you from manually searching for context or executing actions. You can enable or disable Agent mode (tool usage) in the Chat model role settings.


![](agent.gif)

![](agent2.gif)

### Supports all MCP tools

The [Model Context Protocol](https://modelcontextprotocol.io/introduction) is a standard proposed by Anthropic to unify prompts, context, and tool usage. KLiP is compatible with any MCP server through the [MCP settings](#mcpservers).

![](mcp.gif)

### Customize Your Own Prompts

Prompts are reusable instructions and standardized patterns that can be referenced anytime during a chat and easily shared with your team. They are especially helpful for repetitive or complex tasks.

![](prompt_customization.gif)

#### Quick Start

Here's a quick example of setting up a prompt file to review your source code:

1. Create a folder named `.klip/prompts/` at the top level of your workspace.
2. Add a file called `code-reivew.prompt` to this folder. The file name will serve as the name of the slash command you'll use to generate your prompt.
3. Write the following content in `code-reivew.prompt` and save:

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

4. Reload VSCode

To use this prompt, open the source code files you want to review. In the KLiP chat box, type "@prompts" and select the "Code Review" prompt. Press Enter, and KLiP will generate a response based on your predefined prompt.

#### Format

A .prompt file consists of two parts

1. YAML Configuration (above "---"): Set parameters like "temperature" and "description."
2. Prompt Body (below "---"): The actual prompt content

##### YAML Configuration

The "YAML Configuration" is everything above the `---` separator and allows you to specify model parameters. It uses YAML syntax and currently supports the following parameters:

- `name` - The display title
- `description` - The description you will see in the dropdown
- `version` - Can be either "1" (for legacy prompt files) or "2" (this is the default and does not need to be set)

If you don't need any of these parameters, you can omit the YAML configuration and the `---` separator.

##### Prompt Body

In the prompt body, you can reference:

1. Files (absolute or relative paths, based on the workspace root):
   
   - @CHANGELOG.md
   - @src/app/main.py
   - @/Users/someone/Desktop/some-coderepo/src/app/main.py

1. URLs:
   
   - @<https://some.site.com>

2. Context Providers:
  
   - @main.py
   - @open
   - @tree
   - @skeleton
   - ...


### History

You can open your chat history, edit the title of the chat and delete the chat in the History page.

<img width="400" alt="History" src="history.gif">

### Model Customization

If you have specific needs, such as adding a separate KrugleAI 15B model from a remote server, you can do so from the Settings page.

![](model_setup01.png)

KLiP supports models from Anthropic, DeepSeek, and OpenAI, as well as any other models compatible with the OpenAI API protocol. Simply enter your API key and set the API base URL in the advanced settings.

![](model_setup02.png)

### Dashboard

Dashboard allows you to check the token usage status and more.

![](dashboard.png)

---

## Quickstart

1. Follow the deployment guide available [here](../Shasta/deployment_guide.md) to install Shasta, and [here](./deployment_guide.md) to install KLiP.

2. Upon installation, you'll notice the KLiP logo appearing in the left sidebar. Clicking on it will open the KLiP extension.

<img width="400" alt="quick_start" src="quick_start.png">

We highly suggest relocating KLiP to the right sidebar of VS Code. This ensures the file explorer remains accessible while using KLiP, and the sidebar can be easily toggled with a keyboard shortcut (`cmd/ctrl + option/alt + B`).

![](dnd.gif)

3. When you first install and open KLiP, you will see a Setup Wizard.

Step 1: Configure KrugleKnow. Enter the KrugleKnow API URL. If authentication is enabled on your KrugleKnow server, provide the username and password. Otherwise, leave those fields blank.

<img width="500" src="install_klip3.png">

Step 2: Configure the Shasta/Shasta Pro settings. If you've already upgraded to version 0.7.0+ and configured the model, this step will not appear.

<img width="500" src="install_klip4.png">

VSCode will restart once the setup wizard is complete.

<img width="500" src="install_klip5.png">

4. You can now disconnect from the internet and harness the power of AI code development with KLiP.

---

## How to use KLiP

### TL;DR

Incorporating LLMs into your coding process can enhance efficiency when applied appropriately. This guide outlines the scenarios in which we recommend utilizing KLiP and when it might be better to refrain from doing so.

The effectiveness of KLiP depends on the underlying KrugleAI code LLM used to generate edits and explanations. Keep in mind that LLMs may occasionally generate inaccurate suggestions, such as introducing non-existent libraries or syntax. If you encounter a suggestion that doesn't seem right, it's advisable to cross-reference it with relevant documentation.

With KLiP used, you'll develop a sense of when to trust KLiP's suggestions. A good approach to familiarize yourself with it is by experimentation, gaining insights into what yields desirable outcomes. KLiP prompts you to either accept or reject any changes it proposes, providing the flexibility to undo modifications if needed.

If you're uncertain about KLiP's potential to assist with a particular task, consider the following steps:

'Select' refers to the act of selecting a text range in a file and pressing `cmd + L` (macOS) or `ctrl + L` (Windows) to include it in the KLiP chat message.

- **Selection**: Utilize `cmd/crtl + L` to select the code section(s) you wish to understand better and type "tell me how this code works" in the input box.
- **Evaluation**:  If the explanation seems reasonable, while still selecting the code section(s), inquire, "how would you change this code to: **[Your Task]**"?
- **Modification**: If the explanation meets your expectations, you can click the `Apply` button to apply the code. Alternatively, continue selecting the code snippets, press `cmd/crtl + I` to initiate a modification command, and enter **[YOUR TASK]** to directly inline modify the code.
- **Iterative Approach**: If the initial attempt doesn't produce the desired outcome, utilize `cmd/ctrl + shift + backspace` to reject the changes and retry, as KLiP may offer different suggestions with each attempt.
- **Clarification**: If KLiP isn't delivering the desired results, optimize your prompts and provide more specific instructions, clearly articulating your expectations.
- **Breakdown**: If all else fails, consider breaking down the task into smaller sub-tasks and addressing them individually, either with the assistance of the KLiP or manually.

Remember, the responsibility for all code lies with you, whether it's authored by yourself or by an LLM that you directed. Consequently, it's essential to review the output generated by the LLM. To facilitate this process, KLiP GUI offers natural language descriptions of the actions taken by the LLM.

### When to use KLiP

KLiP proves invaluable in various scenarios to aid you in completing tasks efficiently:

#### Simplifying Complex Edits

KLiP is particularly effective in situations where traditional find and replace methods fall short, such as performing an inline edit `cmd/crtl + I` "change all of these to be like that."

**Examples**

- `cmd/crtl + I` "Replace the vertical bar with 'Union' at this location"
- `cmd/crtl + I` "Enhance readability by using more descriptive variable names here"

#### Writing files from scratch

KLiP streamlines the process of initiating various file types, including React components, Python scripts, Shell scripts, Makefiles, unit tests, etc.

**Examples**

- `cmd/crtl + I` "Draft a Python script to retrieve the latest news from The New York Times"
- `cmd/crtl + I` "Integrate a React component for syntax-highlighted code"

#### Crafting Boilerplate from Scratch

KLiP extends its capabilities further by assisting in creating boilerplate structures. For instance, it can facilitate in constructing the framework for a Python package, complete with a typer CLI app for sorting arguments and displaying them.

**Examples**

- `cmd/crtl + I` "Utilize this schema to generate a SQL query that retrieves recently churned users"
- `cmd/crtl + I` "Develop a shell script to back up my home directory to /tmp/"

#### Fix selected code

After selecting the section(s) of code, aim to refine it using KLiP (e.g., `cmd/crtl + I` "modify the function to operate in this manner" or `cmd/crtl + I` "implement this universally").

**Examples**

- `cmd/crtl + I` "adapt this digital ocean Terraform file to function with GCP"
- `cmd/crtl + I` "rewrite this function to be async"

#### Asking About Selected Code or an Entire File

If there's uncertainty regarding how certain code works, select it and ask, "how does this code work?"

**Examples**

- "where within the page should I make this request to the backend?"
- "how can I facilitate communication between these iframes?"

#### Addressing errors

KLiP can assist in elucidating errors/exceptions and suggesting potential remedies. Upon encountering an error/exception in your terminal, press `cmd + shift + R` (macOS) / `ctrl + shift + R` (Windows). This action will transmit the stack trace to KLiP and prompt an explanation of the issue.

#### Determining Appropriate Shell Commands

Rather than shifting focus and becoming sidetracked, you can ask about matters such as "How can I identify running processes on port 8000?"

**Examples**

- "what is the name of the load_dotenv library?"
- "how do I identify running processes on port 8000?"

#### Asking Single-Turn Open-Ended Questions

Instead of leaving your IDE, you can ask open-ended questions that you don't expect to turn into multi-turn conversations.

**Examples**

- "how can I set up a Prisma schema to cascade deletes?"
- "what is the difference between dense and sparse embeddings?"

#### Editing Small Existing Files

You can select an entire file and request KLiP to enhance it as long as the file is not too large.

**Examples**

- `cmd/crtl + I` "here's a connector for PostgreSQL, now create one for Kafka"
- `cmd/crtl + I` "Revise this API call to retrieve all pages"

#### Leveraging Context from Multiple Files

Similar to manual modifications, concentrate on one file at a time. However, if other files contain pertinent information, select those code segments too to be used as additional context.

#### Executing Tasks with Few Steps

Klip can assist with many more tasks, typically those that don't involve too many steps to complete.

**Examples**

- `cmd/crtl + I` "generate an IAM policy for creating a user with read-only access to S3"
- `cmd/crtl + I` "transform this plot into a bar chart within this dashboard component"

### When to not use KLiP

Below are scenarios where KLiP may **not** helpful with at present:

#### In-Depth Debugging

If you're deep into debugging a complex issue spanning multiple files for about 20 minutes, KLiP may not yet assist you in connecting all the dots. However, sharing your progress and seeking suggestions can prompt KLiP to provide ideas for potential solutions.

#### In Parallel Editing of Multiple Files

Currently, KLiP can only handle edits in one file at a time. However, you can guide KLiP to assist you in modifying multiple files sequentially once you've identified the necessary changes.

#### Using Entire File Context

For very large files, KLiP may struggle to incorporate the entire content due to its limited LLM context windows. Consider selecting specific code sections containing relevant ontext, as complete files are rarely needed.

#### Editing Large Files

Similarly, attempting to edict too many lines at once may exceed context window limits and result in sluggish performance when applying suggestions.

#### Selecting Really Long Lines

Selecting overly long lines (e.g. a complex SVG), may encounter similar issues as mentioned above.

#### Tasks with Numerous Steps

While KLiP may not tackle tasks comprehensively in one go, breaking them down into sub-tasks often allows KLiP to provide assistance with each step.

---

## Settings

Click the gear icon in the bottom right corner to customize KLiP settings.

<img width="360" alt="image" src="config.png">

<img width="360" alt="image" src="config2.png">


### Models

You can add a new model or manage model roles in the Model section.

#### Chat

<img width="500" alt="image" src="settings_chat.png">

A "chat model" is a LLM designed to respond in a conversational format. To handle general questions and generate complex code, the best chat models are typically very large—often with over 405 billion parameters—or are specialized code models like the Krugle code LLM, which are trained and fine-tuned for specific use cases.

In KLiP, these models are used for standard chat and VS Code actions. If no specific models are defined for Edit or Apply functions, the selected chat model will also handle those tasks.

Example from the config.yaml file:

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

##### Agent Mode

Agent enhances the Chat model with tools to handle a wide range of coding tasks, allowing it to make decisions and save you from manually searching for context or executing actions. You can enable or disable Agent mode (tool usage) in the Chat model role settings.

Agent operates within the same interface as Chat, so you can continue using the same input field to send messages. Manual methods of providing context—such as tagging @[context providers](#context-providers) or select code from the editor—still work. Currently supported models for Agent mode include: Krugle Code 15B/35B, OpenAI GPT-4o, o1, o1-mini, o3, o3-mini, and Anthropic Claude 3.5/3.7 Sonet.

With Agent, you can give instructions in natural language and let the model handle the task. For example, you might say:

Set the `react/no-unescaped-entities` rule to "off" for all eslint configurations in this project.

Agent will determine the appropriate tools to complete the task.

By default, Agent asks for your permission before using a tool. Click "Approve" to proceed or "Cancel" to deny the action.

<img width="500" alt="image" src="settings_agent2.png">

<img width="500" alt="image" src="settings_agent3.png">

You can configure how the Agent uses each tool by selecting one of the following options:

- **Allowed** (default): Ask the user for permission, displaying "Cancel" and "Approve" buttons.
- **Automatic**: Skip permission requests; the tool is called automatically, and its response is sent directly to the model.
- **Disabled**: The tool is not made available to the model.

<img width="500" alt="image" src="settings_agent.png">

##### Display Related Questions

<img width="800" alt="image" src="settings_related.png">

Enable/disable the related questions.

#### Autocomplete

<img width="500" alt="image" src="settings_autocomplete.png">

An "autocomplete model" is a LLM trained using a special format called fill-in-the-middle (FIM). This format provides the beginning (prefix) and end (suffix) of a code snippet, and the model predicts the missing section in between. Because the task is narrowly focused, smaller models—even those with just 3 billion parameters—can perform well. In contrast, larger chat models often struggle with this task, even when extensively prompted.

In KLiP, autocomplete models are used to provide inline code suggestions as you type. To enable this, the model's role must include  "autocomplete" in the config.yaml file.

Example from the config.yaml file:

```yaml
- name: Krugle Code 15B Chat Local
    model: krugle-code-15b-chat
    provider: shasta
    apiBase: http://localhost:5668
    roles:
      - autocomplete
```

More Options:

- Use Autocomplete Cache – Enable or disable the autocomplete cache.
- Multiline Autocompletions – Controls whether autocomplete supports multiple lines. Options are `always`, `never`, or `auto` (default).
- Disable autocomplete in Files – A comma-separated list of glob patterns to disable autocomplete in matching files (e.g., "_/.md, */.conf").

##### Code autocomplete toggle

To enable/disable the KLiP code autocomplete feature, simply click the KLiP button located in the VSCode status bar. Then toggle the "Enable autocomplete" or "Disable autocomplete" in the dropdown menu.

![](autocomplete.png)

#### Edit

It's often beneficial to use a different model for Edit prompts than for chat prompts, as Edit tasks are typically more code-focused and require less conversational fluency. Therefore, code-specific LLMs like Krugle Code 15B/35B are recommended.

In KLiP, you can assign the “edit” role to a model to indicate it should handle Edit requests. If no edit-specific model is defined, the system defaults to the selected chat model.

Example from the config.yaml file:

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

#### Apply

When editing code, the output from Chat and Edit models often doesn't align well with the existing code. A model with the “apply” role is used to generate a more accurate diff for applying changes to the file.

Example from the config.yaml file:

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

#### Embed

An embeddings model is designed to convert a piece of text into a vector, allowing for quick comparison with other vectors to determine textual similarity. These models are generally smaller, faster, and more cost-efficient than LLMs.

In KLiP, embeddings are generated during indexing and used by `@Codebase` or `@docs` context providers to perform similarity or semantic searches within your local codebase or documentation. KLiP offers two options for embeddings:

- **transformers.js** – A built-in embeddings model integrated into VS Code extension.
- **shasta** – An advanced embeddings model powered by Shasta. For example:

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

### Codebase indexing

<img width="500" alt="image" src="settings_codebase.png">

You can enable or disable codebase indexing, check the indexing status, and trigger a re-index.

### Docs

<img width="500" alt="image" src="settings_docs.png">

You can add or remove docs indexing, check the indexing status, and trigger a re-index. By default, KLiP uses a lightweight tool to crawl documentation sites that don't require JavaScript rendering.

If you need to crawl a site that's dynamically generated, or if you encounter an error, you can enable the `Use Chromium for Docs Crawling`. This will download and install Chromium in the KLiP cache directory.

Once the site is indexed, type `@docs` from the chat box, select your documentation from the dropdown, and KLiP will automatically use similarity search to find relevant sections for your query.

<img width="500" alt="image" src="docs2.png">

![](docs3.png)

Clicking the used context will reveal the source documentation.

<img width="1065" alt="image" src="docs4.png">

KLiP also pre-indexes a number of common documentation sites. These sites' embeddings are hosted by us and downloaded locally after the first request. All other indexing occurs entirely locally. Ensure the domain `krugle-klip.s3.ap-northeast-1.amazonaws.com` is whitelisted in your firewall.

### Appearance

<img width="500" alt="image" src="settings_appearance.png">

- **Show Session Tabs**: When enabled, displays tabs above the chat to help organize and access sessions. Disabled by default.
- **Wrap Code Blocks**: When enabled, allows text to wrap within code blocks. Disabled by default.
- **Show Chat Scrollbar**: When enabled, displays a scrollbar in the chat window. Disabled by default.
- **Disable Session Title Generation**: When disabled, automatically generates a summary title for each chat session after the first message using the current chat model. Disabled by default.
- **Display Raw Markdown**: When enabled, shows responses as raw Markdown text. Disabled by default.

---

## YAML Settings File

You can manually build or edit your config.yaml file, accessible by clicking the `Open Settings (YAML)` link at the top of KLiP settings page.

<img width="300" alt="image" src="config3.png">

### models

The models section defines the language models used in your settings. Models are used for functionalities such as chat, editing, and embedding.

**Properties:**

- `name` (**required**): A unique identifier for the model within your configuration.
- `provider` (**required**): The model provider (e.g., `openai`, `shasta`, `anthropic`).
- `model` (**required**): The specific model name (e.g., `gpt-4o`, `krugle-code-15b-chat`).
- `apiBase`: Optional. Overrides the default API base URL defined for the model.
- `roles`: An array defining the roles the model can perform, such as `chat`, `autocomplete`, `embed`, `edit`, `apply`. Default: `[chat, edit, apply]`.
- `capabilities`: An array of strings indicating model capabilities, overriding KLiP's automatic detection. Supported values include `tool_use` and `image_input`.
- `systemMessage`: Overrides the default system prompt in **Chat** mode
- `defaultCompletionOptions`: Default settings for model completions:
  - `contextLength`: Maximum context size (in tokens).
  - `maxTokens`: This parameter sets the maximum number of tokens that the model can generate in a single inference request. It helps control the length of the generated text and prevents the model from generating overly long responses. In the example above, the maximum number of tokens is set to 2048.
  - `temperature`: This parameter controls the randomness of the generated text. A lower temperature value makes the model more conservative and deterministic, producing more predictable outputs. On the other hand, a higher temperature value increases the randomness, leading to more diverse but potentially less coherent outputs. In the example above, the temperature is set to 1, which is a neutral setting; `0.0` is deterministic, `1.0` is highly random.
  - `topP`: Also known as nucleus sampling, this parameter dynamically adjusts the number of tokens considered based on their cumulative probability mass. It allows the model to generate a diverse range of outputs while ensuring that the total probability mass of the generated tokens stays above a certain threshold (specified by topP). In the example above, topP is set to 0.75, meaning the model considers tokens until the cumulative probability mass exceeds 75%.
  - `topK`: This parameter limits the number of tokens considered at each step of the generation process. It restricts the model to only consider the top k most likely tokens according to their probability distribution. This helps in preventing the model from generating improbable or nonsensical tokens. In the example above, topK is set to 45, meaning only the top 45 tokens with the highest probabilities will be considered at each step。
  - `stop`: An array of stop sequences that end the generation.
  - `n`: Number of completions to generate.
  - `reasoning`: Boolean to enable reasoning mode for Anthropic Claude 3.7+ models.
  - `reasoningBudgetTokens`: Token budget for reasoning in Anthropic Claude 3.7+ models.
- `embedOptions`: Applies when the model has the `embed` role. Used for embedding operations:
  - `maxChunkSize`: Maximum tokens per document chunk (minimum: 128).
  - `maxBatchSize`: Maximum number of chunks per request (minimum: 1).

Example:

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

### context

The `context` section specifies context providers, which deliver additional information to LLMs. Each provider can be customized with specific parameters.

For detailed usage and parameter information for each context provider, refer to the [Context Providers](#context-providers) chapter.

**Properties:**

- `provider` (**required**): The identifier or name of the context provider (e.g., `code`, `docs`, `web`)
- `name`: Optional custom name for the provider
- `params`: Optional settings to configure the provider's behavior.

Example:

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

Rules provide instructions to the model for Chat, Edit, and Agent requests. They are generally not used for other request types, such as autocomplete or apply.

The rules block is an array, and each element can be a simple text string.

Example:

```yaml
rules:
  - Please keep answers concise. Avoid explaining obvious concepts. You can assume I'm familiar with most programming topics.
```

#### .kliprules

You can also define project-specific rules by adding a .kliprules file to the root of your project. This plain text file will override any rules set in config.yaml with its full contents.

Example:

```.kliprules
Please keep answers concise. Avoid explaining obvious concepts. You can assume I'm familiar with most programming topics.
```

### prompts

A list of custom prompts that can be triggered in the chat window using `/PROMPT_NAME`. Each prompt includes a name, description, and the prompt text itself.

Example:

```yaml
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
```

Use the `/inspect` command in the chat window to activate this prompt.

### docs

List of documentation sites to be indexed. 

**Properties:**

- `name` (**required**): The name of the documentation site, shown in `@docs` dropdown menus and other UI elements.
- `startUrl` (**required**): The starting page for crawling—typically the root or introduction page of the documentation.
- `maxDepth`: The maximum depth of links to follow during crawling. Default is `4`.
- `favicon`: URL of the site’s favicon. Defaults to `/favicon.ico` relative to `startUrl`.
- `useLocalCrawling`: Bypasses the default crawler and uses only the local crawler.

Example:

```yaml
docs:
  - name: Krugle
    startUrl: https://krugle.co.jp
    favicon: ""
```

Indexing will start when the file is saved.

### mcpServers

The [Model Context Protocol](https://modelcontextprotocol.io/introduction) is a standard proposed by Anthropic to unify prompts, context, and tool usage. KLiP is compatible with any MCP servers.

**Properties:**

- `name` (**required**): The name of the MCP server.
- `command` (**required**): The command used to launch the server.
- `args`: Optional. An array of arguments for the command.
- `env`: Optional. A map of environment variables for the server process.
- `connectionTimeout`: Optional. The server connection timeout in milliseconds.

Example:

```yaml
mcpServers:
  - name: Time
    command: uvx
    args:
      - mcp-server-time
      - --local-timezone
      - Asia/Tokyo
```

### Complete YAML Config Example

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

## Context Providers

Context Providers enable you to simply type '@' and access a dropdown menu of content that can all serve as context for the Language Model (LLM). Each context provider functions as a plugin. If you need to reference a source of information that isn't available, you can request a new context provider to Krugle support team.

For instance, suppose you're addressing a new GitHub Issue. You type `@issue` and choose the relevant one. Now, KLiP can access the issue title and contents. If you know the issue relates to files like 'readme.md' and 'foobar.py', you can type `@readme` and `@foobar` to locate and select them. Consequently, these three "Context Items" are seamlessly integrated with the rest of your input.

<img width="449" alt="image" src="context.png">

To use any of the built-in context providers, navigate to config.yaml and include them in the contextProviders list.

### File

Type `@file` to reference any file in your current workspace.

```yaml
context:
  - provider: file
```

### Open Files

Use `@open` to access the contents of all open files. Set `onlyPinned` to `true` to reference only pinned files.

```yaml
context:
  - provider: open
    params:
      onlyPinned: true
```

### Current File

Use `@currentFile` to access the content of the current file that you are editing/viewing.

```yaml
context:
  - provider: currentFile
```

### Code

Use `@code` to reference specific functions or classes from across your project.

```yaml
context:
  - provider: code
```

### Git Diff

Use `@diff` to refer to all changes made in your current branch. This is helpful for summarizing your work or requesting a general review before committing.

![](diff.png)

```yaml
context:
  - provider: diff
```

### Git Commits

Use `@commit` to reference specific Git commit metadata, diffs, or all recent commits.

```yaml
context:
  - provider: commit
    params:
      Depth: 50
      LastXCommitsDepth: 10
```

The depth specifies how many commits are loaded into the submenu, with a default of 50. LastXCommitsDepth determines how many recent commits are included, defaulting to 10.

### Codebase

Use `@codebase` to automatically retrieve the most relevant snippets from your codebase.

```yaml
context:
  - provider: codebase
```

**Configuration**

You can configure the behavior of the codebase context provider with several options. These settings apply to both the `@codebase` and `@folder` context providers and can be adjusted in `config.yaml`:

**File Location:** `~/.klip/config.yaml`

```yaml
context:
  - provider: codebase
      params:
        nFinal: 5
        nRetrieve: 25
        useReranking: true
```

- **`nRetrieve`:** Number of results to initially retrieve from the vector database (default: 25).
  
- **`nFinal`:** Final number of results to use after re-ranking (default: 5).

- **`useReranking`:** Whether to use re-ranking, which initially selects `nRetrieve` results, then uses an LLM to choose the top `nFinal` results (default: true).

**Ignoring Files During Indexing**

KLiP respects `.gitignore` files to determine which files should not be indexed. To exclude additional files, you can create a `.klipignore` file, which follows the same rules as `.gitignore`.

To force a refresh of the index, reload the VS Code window by pressing `cmd/ctrl + shift + P`, then selecting "Reload Window."

### Folder

Type `@folder` to use the same retrieval mechanism as `@codebase`, but limited to a single folder.

```yaml
context:
  - provider: folder
```

### Exact search within workspace via RegExp pattern

Type `@search` to reference the results of a codebase search, similar to the results you would obtain from a search in VS Code.

> Note: Due to the potentially large data size of this context provider, deploying Shasta locally without GPU acceleration may lead to slow performance. Therefore, it is recommended to deploy Shasta locally with GPU or use the remotely deployed KrugleAI Base Pro service on a GPU instance for faster inference speed and improved performance.

```yaml
context:
  - provider: search
```

### File Tree

Type `@tree` to reference the hierarchical structure of your current workspace. This will allow the LLM to view the nested directory layout of your project.

> Note: Due to the potentially large data size of this context provider, deploying Shasta locally without GPU acceleration may lead to slow performance. Therefore, it is recommended to deploy Shasta locally with GPU or use the remotely deployed KrugleAI Base Pro service on a GPU instance for faster inference speed and improved performance.

```yaml
context:
  - provider: tree
```

### URL

Type `@url` and enter a URL. KLiP will then convert it into a Markdown document for the LLM.

```yaml
context:
  - provider: url
```

### Documentation

To index and retrieve snippets from any documentation site, type `@docs`.

```yaml
context:
  - provider: docs
```

### Clipboard

Reference the clipboard items

```yaml
context:
  - provider: clipboard
```

### Terminal

Use `@terminal` to access the contents of your IDE's terminal.

```yaml
context:
  - provider: terminal
```

### GitHub Issues

Type `@issue` to directly reference conversations within GitHub issues. Make sure to include your own [GitHub personal access token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token) to avoid rate limiting:

```yaml
context:
  - provider: issue
    params:
      repos:
        - owner: krugle2
          repo: klip
      githubToken: ghp_xxxxxxxxxxxxxx
```

### GitLab Merge Request

Type `@gitlab-mr` to reference an open merge request (MR) for the current branch on GitLab.

**Configuration**

Create a [personal access token](https://docs.gitlab.com/ee/user/profile/personal_access_tokens.html) with the `read_api` scope, then add the following to your configuration:

```yaml
context:
  - provider: gitlab-mr
    params:
      token: "xxxxxxxxxxxxxxxxxxxx"
```

**Using Self-Hosted GitLab**

To communicate with a self-hosted GitLab instance, set the `domain` parameter in your configuration. By default, this is set to `gitlab.com`.

```yaml
context:
  - provider: gitlab-mr
    params:
      token: "xxxxxxxxxxxxxxxxxxxx"
      domain: "gitlab.example.com"
```

**Filtering Comments**

If you're editing specific code, you can filter out comments from other files by setting `filterComments` to `true`.

### Jira Issues

Type `@jira` to reference the conversation in a Jira issue. Be sure to include your own [Atlassian API Token](https://id.atlassian.com/manage-profile/security/api-tokens), or use your `email` and `token`, with the token set as your password for basic authentication. If you're using your own Atlassian API Token, do not configure your email.

```yaml
context:
  - provider: jira
    params:
      domain: company.atlassian.net
      token: ATATT...
```

**Jira Datacenter Support**

This context provider supports both Jira API versions 2 and 3. By default, it uses version 3 (the cloud version), but if you are using the Jira datacenter version, you'll need to set the API Version to 2 using the `apiVersion` property.

```yaml
context:
  - provider: jira
    params:
      apiVersion: "2"
```

**Issue Query**

By default, the following query is used to find issues:

```sql
assignee = currentUser() AND resolution = Unresolved order by updated DESC
```

You can override this query by setting the `issueQuery` parameter.

### Operating System

Type `@os` to reference your current operating system's architecture and platform.

```yaml
context:
  - provider: os
```

### Codebase Skeleton

Provides an overview of all files in the codebase or a subfolder, highlighting the key symbols of top-level classes, functions, and methods in each file. It includes the critical lines of code where these symbols are defined, helping the model better understand how each piece of code connects to the overall codebase.

```yaml
context:
  - provider: skeleton
```

### Problems

Reference the Problems from the current file.

```yaml
context:
  - provider: problems
```

### KrugleKnow

This is required to enable KrugleKnow Search feature.

```yaml
context:
  - provider: krugleknow
```

### PostgreSQL - Work in Progress, Coming Soon

To reference the schema of a table along with sample rows, type `@postgres`.

### Database Tables - Work in Progress, Coming Soon

Type `@database` to reference table schemas. You can use the drop-down menu or begin typing table names based on your configuration.


### Web Search

Once agent mode is enabled, KLiP can use the latest internet data to provide more accurate and up-to-date answers.

In your config.yaml, add the `web` context provider as shown in the example below. You can get a free API key at [serper.dev](https://serper.dev/).

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

### Debugger: Local Variables

Type `@debugger`s to reference the local variables within the top n levels (defaulting to 3) of the call stack for that thread.

```yaml
context:
  - provider: debugger
    params:
      stackDepth: 3
```

### Requesting Context Providers

If you don't find what you need, reach out to the Krugle support team or create an issue [here](https://github.com/krugle2/Klip/issues/new) to request a new ContextProvider.

---

## FAQ

### Why KLiP keeps outputting garbled text

Please start by examining the `shasta.log` file. On macOS or Windows, you can locate it at `$SHASTA_HOME/shasta.log`. While on Linux, the location is `/var/log/shasta/shasta.log`. If you encounter the errors listed below, it indicates insufficient RAM on your machine.

```log
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
```

**Solution:**

Adjust the `contextLength` and `maxTokens` parameters in your KLiP config.yaml file. Here are some example value pairs: `16384/4096`, `8192/4096`, `8192/2048`, `4096/2048`, `2048/1024`, `2048/512`, `1024/512`.

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

### How can I customize which files are indexed?

Klip adheres to the rules of `.gitignore` files to determine which files should not be indexed. To exclude additional files, you can add them to a `.klipignore` file, which follows the same rules as `.gitignore`.

For example, you can add a `.klipignore` file at top level of your project.

```shell
.vscode/
node_modules/
dist
media
.git
*.log

# Add your other rules here
# ...
```

### Why doesn't Shasta always use all CPU cores?

Simply add the `numThreads` option.

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

### Why doesn't Shasta always use the GPU?

Shasta uses dedicated GPU (NVIDIA/AMD) VRAM for inference. The CPU is always required because tasks like loading model parameters still need to read the model file into RAM before transferring it to VRAM.

#### 100% GPU Usage

```text
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

All model weights are loaded into VRAM. The next factor is the context window size.

If there's enough available VRAM to handle the context window size, the GPU will be used. If not, the CPU will handle the inference.

The context window size can be adjusted on the client side (AI Web or KLiP). For example, you can reduce the `contextLength` in KLiP by modifying the `config.yaml`:

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

#### Partial CPU/GPU Usage

When VRAM is nearly full or completely full, the remaining parts of the model are loaded into system memory, and the CPU handles inference indefinitely. However, the GPU is still faster and more efficient than using the CPU alone.

```shell
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

Though 100% GPU usage, but VRAM only has for example 500 MB free VRAM.

or

```shell
krugle-code-10b:latest c1669e6bec24 10 GB 46%/54% CPU/GPU
```

### I'm not seeing any code completions

Follow these steps to ensure everything is set up correctly:

1. Ensure the "Enable Tab Autocomplete" setting is checked (in VS Code, toggle it by clicking the "Klip" button in the status bar).
2. Verify that Shasta is installed, set up, and running.
3. Run `shasta ls` to confirm that the models are downloaded.
4. Disable any other completion providers, as they may interfere.
5. Avoid using KLiP for chat simultaneously, as it will cause Shasta to repeatedly load and unload models from memory, resulting in slow or no responses for both.
6. Check the log output for potential errors (`cmd/ctrl + shift + P` -> "Toggle Developer Tools" -> "Console" tab in VS Code).
7. If you still have issues, please let us know, and we'll assist as soon as possible.

### Autocompletions are slow

This depends on your hardware.

### Autocompletions don't know about my code

We are working on improving the accuracy of this system and expect significant improvements in the coming weeks.

### Autocompletions contain formatting errors

If you notice a recurring pattern of mistakes, please report it to us. We will address and fix it as soon as possible.

---

License

[© 2025 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
