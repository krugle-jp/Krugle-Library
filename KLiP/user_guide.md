# KrugleAI KLiP User Guide

**Version**: v0.6.1-beta

<div align="center">
<img width="500" alt="KLiP" src="logo.png">
</div>

- [KrugleAI KLiP User Guide](#krugleai-klip-user-guide)
  - [Introduction](#introduction)
  - [Features](#features)
    - [Understand your code quickly and easily](#understand-your-code-quickly-and-easily)
    - [Trigger actions with slash commands](#trigger-actions-with-slash-commands)
    - [Add classes, files, and more into the context](#add-classes-files-and-more-into-the-context)
    - [Inline Editing](#inline-editing)
    - [AI-powered code autocompletion (🚧 Experimental)](#ai-powered-code-autocompletion--experimental)
    - [Reference your organization's code and documentation](#reference-your-organizations-code-and-documentation)
    - [Codebase Retrieval](#codebase-retrieval)
    - [Chat with your documentation (🚧 Experimental)](#chat-with-your-documentation--experimental)
    - [Web search mode](#web-search-mode)
    - [Quick Lens Tools (🚧 Experimental)](#quick-lens-tools--experimental)
      - [Prerequisite](#prerequisite)
      - [How to Disable Quick Lens Tools](#how-to-disable-quick-lens-tools)
      - [Custom Quick Lens Tools](#custom-quick-lens-tools)
        - [Example Use Cases](#example-use-cases)
    - [Customize Your Own Prompts (🚧 Experimental)](#customize-your-own-prompts--experimental)
      - [Quick Start](#quick-start)
      - [Format](#format)
        - [Preamble](#preamble)
        - [System Message](#system-message)
        - [Built-in Variables](#built-in-variables)
        - [Context Providers](#context-providers)
    - [History](#history)
    - [Model Setup](#model-setup)
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
  - [Configuration](#configuration)
    - [Modifying the LLMs](#modifying-the-llms)
    - [Adjustment of LLM Parameters](#adjustment-of-llm-parameters)
    - [Suggested follow up questions](#suggested-follow-up-questions)
    - [AI-powered code autocompletion](#ai-powered-code-autocompletion)
      - [`tabAutocompleteModel`](#tabautocompletemodel)
      - [`tabAutocompleteOptions`](#tabautocompleteoptions)
      - [Example](#example)
      - [Code autocomplete toggle](#code-autocomplete-toggle)
    - [Context Providers](#context-providers-1)
      - [Built-in Context Providers](#built-in-context-providers)
        - [Files](#files)
        - [Open Files](#open-files)
        - [Code](#code)
        - [Git Diff](#git-diff)
        - [Codebase Retrieval](#codebase-retrieval-1)
        - [Folder](#folder)
        - [Exact search within workspace via RegExp pattern](#exact-search-within-workspace-via-regexp-pattern)
        - [File Tree](#file-tree)
        - [URL](#url)
        - [Documentation](#documentation)
        - [Terminal](#terminal)
        - [GitHub Issues](#github-issues)
        - [GitLab Merge Request](#gitlab-merge-request)
        - [Jira Issues](#jira-issues)
        - [Operating System](#operating-system)
        - [Codebase Skeleton](#codebase-skeleton)
        - [PostgreSQL - Work in Progress, Coming Soon](#postgresql---work-in-progress-coming-soon)
        - [Database Tables - Work in Progress, Coming Soon](#database-tables---work-in-progress-coming-soon)
        - [Debugger: Local Variables - Work in Progress, Coming Soon](#debugger-local-variables---work-in-progress-coming-soon)
        - [Requesting Context Providers](#requesting-context-providers)
    - [Slash Commands](#slash-commands)
      - [Built-in Slash Commands](#built-in-slash-commands)
        - [/edit](#edit)
        - [/comment](#comment)
        - [/share](#share)
        - [/cmd](#cmd)
        - [/commit](#commit)
      - [Custom Commands Using Natural Language (DEPRECATED)](#custom-commands-using-natural-language-deprecated)
  - [FAQ](#faq)
    - [Why KLiP is not activated?](#why-klip-is-not-activated)
      - [Invalid credentials for](#invalid-credentials-for)
    - [Why KLiP keeps outputting garbled text](#why-klip-keeps-outputting-garbled-text)
    - [How can I customize which files are indexed?](#how-can-i-customize-which-files-are-indexed)
    - [Why doesn't  Shasta always use all CPU cores?](#why-doesnt--shasta-always-use-all-cpu-cores)
    - [Why doesn't Shasta always use the GPU?](#why-doesnt-shasta-always-use-the-gpu)
      - [100% GPU Usage](#100-gpu-usage)
      - [Partial CPU/GPU Usage](#partial-cpugpu-usage)
    - [I'm not seeing any code completions](#im-not-seeing-any-code-completions)
    - [Completions are slow](#completions-are-slow)
    - [Completions don't know about my code](#completions-dont-know-about-my-code)
    - [Completions contain formatting errors](#completions-contain-formatting-errors)
    - [Why Quick Lens Tools are not shown?](#why-quick-lens-tools-are-not-shown)

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
- Simply type ***@*** to reference various sources while communicating with the LLM. Additional context providers forthcoming, such as `@docs` for code language and framework documentation, `@krugle` for files or documentation indexed by the Krugle Enterprise platform, `@jira` for referencing issues from Jira, and more.
- We offer extensive configuration options to tailor the extension to your specific workflows.
- Utilize our local tab-autocomplete for inline suggestions and rapid boilerplate code writing (alpha).

## Features

### Understand your code quickly and easily

![](code_explanation.gif)

If you're ever confused by a piece of code, KLiP can break it down for you, providing a clear and concise explanation that speeds up debugging and comprehension.

Press `cmd + L` (Mac) or `ctrl + L` (Windows) to get insights into the code you're working on.

### Trigger actions with slash commands

![](slash_commands.gif)

Slash commands in KLiP let you perform actions quickly and efficiently without leaving your coding environment.

### Add classes, files, and more into the context

![](add_context.gif)

Copying and pasting context into the chat box can disrupt your workflow. KLiP allows you to add classes, files, and more to your current context, so you can access everything you need in one place. It also addresses issues with LLM knowledge cutoffs.

### Inline Editing

Refactor your code directly where you're working.

![](inline_edit_01.gif)

There are built-in inline editing tools available for your selected code.

![](inline_edit_02.gif)

### AI-powered code autocompletion (🚧 Experimental)

KLiP now supports AI-powered code autocompletion. Easily get code suggestions by simply pressing Tab.

![](ai_code_autocomplete.gif)

![](ai_code_autocomplete_02.gif)

### Reference your organization's code and documentation

Krugle Enterprise is a central search engine that offers federated access to an organization's codebase, code artifacts, and technical documentation. It provides tools for flexible analysis and search capabilities, enabling users to identify critical code patterns, security vulnerabilities, and application issues in real-time. The platform is designed to enhance collaboration and efficiency within development teams by making technical information easily accessible and actionable at scale.

With KLiP, you can search and browse any code files or documentation indexed in the Krugle Enterprise platform without needing to clone, download, or index them locally.

![](ke_search.gif)

```json
{
  "name": "krugle",
}
```

### Codebase Retrieval

Ask questions about your codebase.

![](codebase_retrieval.gif)

KLiP indexes your codebase, enabling it to automatically pull in the most relevant context from across your workspace. This is achieved through a combination of embeddings-based retrieval and keyword search. By default, all embeddings are calculated and stored locally.

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

### Chat with your documentation (🚧 Experimental)

The `@docs` context provider allows you to interact with your documentation directly within KLiP. This feature enables you to index any static site or GitHub markdown pages, making it easier to access and utilize your documentation while coding.

![](docs.gif)

The `@docs` context provider works by crawling specified documentation sites, generating embeddings, and storing them locally for you. This process allows for quick and efficient access to your documentation content.

We also offer a selection of pre-indexed documentation sites for popular frameworks and libraries. You can find them from the dropdown list of the `@docs` context provider.

To add your own documentations please read more [here](#documentation).

![](docs_add.gif)

### Web search mode

KLiP can use the latest internet data to answer questions, delivering more accurate and up-to-date responses.

![](web_search.gif)

In your config.json, add the slash command `web` as shown in the example below. You can get a free API key at [serper.dev](https://serper.dev/).

```json
{
  ...

  "slashCommands": [
    {
      "name": "web",
      "description": "Web-enabled assistant bot that searches the internet to inform its responses.",
      "params": {
        "provider": "serper.dev",
        "type": "google",
        "api_key": "YOUR_SERPER_DEV_API_KEY",
        "country": "Japan",
        "language": "Japanese"
      }
    }
  ]

  ...
}
```

### Quick Lens Tools (🚧 Experimental)

Quick Lens Tools streamline your development workflow by enabling quick selection of an entire class or function for rapid editing. Configure custom quick lens tools to perform complex operations with a single click.

![](quick_lens_actions.gif)

#### Prerequisite

> You must have the [Language Server Protocol](https://microsoft.github.io/language-server-protocol/) extension installed for the language of the file you have open. If your VSCode lacks Language Server Protocol support for the language, search for "Language Server Protocol" in the VSCode extension marketplace.

For example, if you want to use KLiP Quick Lens for Java, and you haven't enable Java lang for your VSCode, you can search and install the "Extension Pack for Java" which contains the language server protocol from the marketplace.

![](quick_lens_actions_prereq.png)

#### How to Disable Quick Lens Tools

Quick Lens Tools are enabled by default. To disable them, open the settings menu (`cmd/ctrl + ,`), search for `klip.enableQuickLensTools`, and uncheck the box to disable.

#### Custom Quick Lens Tools

Custom Quick Lens Tools allow you to tailor functionality to your specific needs, extending beyond the default actions. You can easily configure these custom actions in your `~/.klip/config.json` file.

##### Example Use Cases

1. **Code Migration**  
   A tool that converts a class or function into another language. For example, convert any code into Java:

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

2. **Generate Inline Docstring**  
   A tool that generates and inserts a docstring for your class or function.

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

3. **Write an Inline Unit Test**  
   A tool that generates and inserts a unit test above the selected code.

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

4. **Send Code to Chat Panel for Detailed Explanation**  
   The default "Explain" provides a brief overview of the code. This quick action sends the code and prompt to the chat for a more detailed explanation.

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

5. **Create a TypeScript Interface**  
   A quick action that generates and inserts a TypeScript interface above the selected code.

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

### Customize Your Own Prompts (🚧 Experimental)

You can create customized prompt files to standardize common patterns and share LLM prompts with your team. These files simplify the process of building and using prompts.

![](prompt_customization.gif)

#### Quick Start

Here's a quick example of setting up a prompt file to write unit tests using Jest:

1. Create a folder named `.prompts/` at the top level of your workspace.
2. Add a file called `ut.prompt` to this folder. The file name will serve as the name of the slash command you'll use to generate your prompt.
3. Write the following content in `ut.prompt` and save:

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

To use this prompt, select the code from file view and use `cmd/ctrl + L` to select it in the KLiP sidebar. Then, type "/" to see the list of slash commands and choose "ut" (this is the new slash command). Press enter, and the LLM will generate a response based on your prompt file.

#### Format

> This format is experimental and subject to change.

##### Preamble

The "preamble" is everything above the `---` separator and allows you to specify model parameters. It uses YAML syntax and currently supports the following parameters:

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

If you don't need any of these parameters, you can omit the preamble and the `---` separator.

##### System Message

To add a system message, start the body with `<system></system>` tags, as shown in the example above, and place your system message inside.

##### Built-in Variables

The following built-in variables are available:

- `{{{ input }}}` - The full text from the input box in the sidebar sent along with the slash command
- `{{{ currentFile }}}` - The currently open file in your IDE
- `{{{ ./path/to/file.js }}}` - Any file can be directly referenced

##### Context Providers

Any KLiP context providers added to your `config.json` can be referenced by their name. Context providers that accept input are also supported.

- `{{{ terminal }}}` - The contents of the terminal
- `{{{ url "https://foobar.com" }}}` - The contents of a URL

### History

You can open your chat history, edit the title of the chat and delete the chat in the History page.

<img width="400" alt="History" src="history.gif">

### Model Setup

If you have specific needs, such as adding a separate KrugleAI 10B model from a remote server, you can do so by selecting the model from the chat box and adding a new 10B model from the KrugleAI Shasta provider. Further changes can be made by clicking the gear icon at the bottom right to edit the `config.json` file.

![](model_setup01.png)

KLiP also supports OpenAI models and any models compatible with the OpenAI API protocol. Just add your API key and specify the API base URL in the advanced settings.

![](model_setup02.png)

### Dashboard

Dashboard allows you to check the indexing status, token usage status and more.

![](dashboard.png)

---

## Quickstart

1. Follow the deployment guide available [here](../Shasta/deployment_guide.md) to install Shasta, and [here](./deployment_guide.md) to install KLiP.

2. Upon installation, you'll notice the KLiP logo appearing in the left sidebar. Clicking on it will open the KLiP extension.

<img width="400" alt="quick_start" src="quick_start.png">

We highly suggest relocating KLiP to the right sidebar of VS Code. This ensures the file explorer remains accessible while using KLiP, and the sidebar can be easily toggled with a keyboard shortcut (`cmd/ctrl + option/alt + B`).

![](dnd.gif)

3. Follow the KLiP setup wizard to configure your models

![](setup_wizard.png)

4. You can now disconnect from the internet and harness the power of AI code development with KLiP.

---

## How to use KLiP

### TL;DR

Incorporating LLMs into your coding process can enhance efficiency when applied appropriately. This guide outlines the scenarios in which we recommend utilizing KLiP and when it might be better to refrain from doing so.

The effectiveness of KLiP depends on the underlying KrugleAI code LLM used to generate edits and explanations. Keep in mind that LLMs may occasionally generate inaccurate suggestions, such as introducing non-existent libraries or syntax. If you encounter a suggestion that doesn't seem right, it's advisable to cross-reference it with relevant documentation.

With KLiP used, you'll develop a sense of when to trust KLiP's suggestions. A good approach to familiarize yourself with it is by experimentation, gaining insights into what yields desirable outcomes. KLiP prompts you to either accept or reject any changes it proposes, providing the flexibility to undo modifications if needed.

If you're uncertain about KLiP's potential to assist with a particular task, consider the following steps:

'Select' refers to the act of selecting a text range in a file and pressing `cmd + L` (macOS) or `ctrl + L` (Windows) to include it in the KLiP chat message.

- **Selection**: Select the code section(s) you wish to understand better and type "tell me how this code works" in the input box.
- **Evaluation**: If the explanation seems reasonable, while still selecting the code section(s), inquire, "how would you change this code to [INSERT TASK]?"
- **Modification**: If the explanation meets expectations, while still selecting the code section(s), input `/edit [INSERT TASK]`. If you're satisfied with the suggested changes, use `cmd/crtl + shift + enter` to implement them.
- **Iterative Approach**: If the initial attempt doesn't produce the desired outcome, utilize `cmd/ctrl + shift + backspace` to reject the changes and retry, as KLiP may offer different suggestions with each attempt.
- **Clarification**: If KLiP isn't delivering the desired results, provide more specific instructions, clearly articulating your expectations.
- **Breakdown**: If all else fails, consider breaking down the task into smaller sub-tasks and addressing them individually, either with the assistance of the code LLM or manually.

Remember, the responsibility for all code lies with you, whether it's authored by yourself or by an LLM that you directed. Consequently, it's essential to review the output generated by the LLM. To facilitate this process, KLiP GUI offers natural language descriptions of the actions taken by the LLM.

### When to use KLiP

KLiP proves invaluable in various scenarios to aid you in completing tasks efficiently:

#### Simplifying Complex Edits

KLiP is particularly effective in situations where traditional find and replace methods fall short, such as executing commands like "/edit change all of these to be like that."

**Examples**

- "/edit Replace the vertical bar with 'Union' at this location"
- "/edit Enhance readability by using more descriptive variable names here"

#### Writing files from scratch

KLiP streamlines the process of initiating various file types, including React components, Python scripts, Shell scripts, Makefiles, unit tests, etc.

**Examples**

- "/edit Draft a Python script to retrieve the latest news from The New York Times"
- "/edit Integrate a React component for syntax-highlighted code"

#### Crafting Boilerplate from Scratch

KLiP extends its capabilities further by assisting in creating boilerplate structures. For instance, it can facilitate in constructing the framework for a Python package, complete with a typer CLI app for sorting arguments and displaying them.

**Examples**

- "/edit Utilize this schema to generate a SQL query that retrieves recently churned users"
- "/edit Develop a shell script to back up my home directory to /tmp/"

#### Fix selected code

After selecting the section(s) of code, aim to refine it using KLiP (e.g., "/edit modify the function to operate in this manner" or "/edit implement this universally").

**Examples**

- "/edit adapt this digital ocean Terraform file to function with GCP"
- "/edit rewrite this function to be async"

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

- "/edit here's a connector for PostgreSQL, now create one for Kafka"
- "/edit Revise this API call to retrieve all pages"

#### Leveraging Context from Multiple Files

Similar to manual modifications, concentrate on one file at a time. However, if other files contain pertinent information, select those code segments too to be used as additional context.

#### Executing Tasks with Few Steps

Klip can assist with many more tasks, typically those that don't involve too many steps to complete.

**Examples**

- "/edit generate an IAM policy for creating a user with read-only access to S3"
- "/edit transform this plot into a bar chart within this dashboard component"

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

## Configuration

You can manually build your config.json file, accessible by clicking the gear icon at the bottom right of KLiP.

<img width="486" alt="image" src="config.png">

### Modifying the LLMs

In the config.json file, locate the "models" property, which contains a list of the models saved for use with KLiP:

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

By simply specifying the model properties, KLiP will automatically detect prompt templates and other pertinent information.

However, if you are using KrugleAI Base Pro service, before customizing the config.json file, ensure that you've made the necessary changes to KrugleAI Base Pro.

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

e.g.

- (Optional) Switch the LLM in the KAI_FLAGS.txt from `%KRUGLE_AI_BASE_HOME`.
- (Optional) Change the API key in the KAI_FLAGS.txt from `%KRUGLE_AI_BASE_HOME`.

### Adjustment of LLM Parameters

You can modify the parameters of the LLM to manage its randomness and creativity in the LLM output.

Available parameters are `temperature`, `topK`, `topP`, `maxTokens`. These parameters are commonly used in GPT (Generative Pre-trained Transformer) models, including KrugleAI models. They control the behavior and quality of the generated text.

e.g.

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

Here's a brief explanation of each:

1. **Temperature**: This parameter controls the randomness of the generated text. A lower temperature value makes the model more conservative and deterministic, producing more predictable outputs. On the other hand, a higher temperature value increases the randomness, leading to more diverse but potentially less coherent outputs. In the example above, the temperature is set to 1, which is a neutral setting.

2. **Top-k**: This parameter limits the number of tokens considered at each step of the generation process. It restricts the model to only consider the top k most likely tokens according to their probability distribution. This helps in preventing the model from generating improbable or nonsensical tokens. In the example above, topK is set to 45, meaning only the top 45 tokens with the highest probabilities will be considered at each step.

3. **Top-p (nucleus sampling)**: Also known as nucleus sampling, this parameter dynamically adjusts the number of tokens considered based on their cumulative probability mass. It allows the model to generate a diverse range of outputs while ensuring that the total probability mass of the generated tokens stays above a certain threshold (specified by topP). In the example above, topP is set to 0.75, meaning the model considers tokens until the cumulative probability mass exceeds 75%.

4. **Max tokens**: This parameter sets the maximum number of tokens that the model can generate in a single inference request. It helps control the length of the generated text and prevents the model from generating overly long responses. In the example above, the maximum number of tokens is set to 2048.

These parameters are often adjusted based on the specific requirements of the task and the desired characteristics of the generated text.

### Suggested follow up questions

Suggested follow up questions feature is enabled by default. To disable it, open the settings menu (`cmd/ctrl + ,`), search for `klip.showFollowUp`, and uncheck the box to disable.

### AI-powered code autocompletion

#### `tabAutocompleteModel`

This object is similar to those in the `"models"` array of `config.json`, but you should always select a smaller code base model like "krugle-base-1.5b-local".

#### `tabAutocompleteOptions`

This object allows you to customize the behavior of code autocomplete. The available options are:

- `useCopyBuffer`: Determines whether to consider the copy buffer when constructing the prompt. (Boolean)
- `useFileSuffix`: Determines whether to use the file suffix in the prompt. (Boolean)
- `maxPromptTokens`: The maximum number of prompt tokens to use. A smaller number yields faster completions but less context. (Number)
- `debounceDelay`: The delay in milliseconds before triggering autocomplete after a keystroke. (Number)
- `maxSuffixPercentage`: The maximum percentage of the prompt that can be dedicated to the suffix. (Number)
- `prefixPercentage`: The percentage of the input that should be dedicated to the prefix. (Number)
- `template`: An optional template string for autocomplete, rendered with the Mustache templating language, using the 'prefix' and 'suffix' variables. (String)
- `multilineCompletions`: Whether to enable multiline completions ("always", "never", or "auto"). Defaults to "auto".

#### Example

The default code autocomplete configuration is as follows. If you cannot find this setting in your config.json file, you can manually copy and add the `tabAutocompleteModel` setting to your config.json.

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

#### Code autocomplete toggle

To enable/disable the KLiP code autocomplete feature, simply click the KLiP button located in the VSCode status bar. Then toggle the "Enable autocomplete" or "Disable autocomplete" in the dropdown menu.

![](autocomplete.png)


### Context Providers

Context Providers enable you to simply type '@' and access a dropdown menu of content that can all serve as context for the Language Model (LLM). Each context provider functions as a plugin. If you need to reference a source of information that isn't available, you can request a new context provider to Krugle support team.

For instance, suppose you're addressing a new GitHub Issue. You type `@issue` and choose the relevant one. Now, KLiP can access the issue title and contents. If you know the issue relates to files like 'readme.md' and 'foobar.py', you can type `@readme` and `@foobar` to locate and select them. Consequently, these three "Context Items" are seamlessly integrated with the rest of your input.

<img width="449" alt="image" src="context.png">

#### Built-in Context Providers

To use any of the built-in context providers, navigate to config.json and include them in the contextProviders list.

##### Files

Type `@file` to reference any file in your current workspace.

```json
{ "name": "file" }
```

##### Open Files

Use `@open` to access the contents of all open files. Set `onlyPinned` to `true` to reference only pinned files.

```json
{ "name": "open", "params": { "onlyPinned": true } }
```

##### Code

Use `@code` to reference specific functions or classes from across your project.

```json
{ "name": "code" }
```

##### Git Diff

Use `@diff` to refer to all changes made in your current branch. This is helpful for summarizing your work or requesting a general review before committing.

![](diff.png)

```json
{ "name": "diff" }
```

##### Codebase Retrieval

Use `@codebase` to automatically retrieve the most relevant snippets from your codebase.

```json
{ "name": "codebase" }
```

**Configuration**

You can configure the behavior of the codebase context provider with several options. These settings apply to both the `@codebase` and `@folder` context providers and can be adjusted in `config.json`:

**File Location:** `~/.klip/config.json`

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

- **`nRetrieve`:** Number of results to initially retrieve from the vector database (default: 25).
  
- **`nFinal`:** Final number of results to use after re-ranking (default: 5).

- **`useReranking`:** Whether to use re-ranking, which initially selects `nRetrieve` results, then uses an LLM to choose the top `nFinal` results (default: true).

**Ignoring Files During Indexing**

KLiP respects `.gitignore` files to determine which files should not be indexed. To exclude additional files, you can create a `.klipignore` file, which follows the same rules as `.gitignore`.

To force a refresh of the index, reload the VS Code window by pressing `cmd/ctrl + shift + P`, then selecting "Reload Window."

##### Folder

Type `@folder` to use the same retrieval mechanism as `@codebase`, but limited to a single folder.

```json
{ "name": "folder" }
```

##### Exact search within workspace via RegExp pattern

Type `@search` to reference the results of a codebase search, similar to the results you would obtain from a search in VS Code.

> Note: Due to the potentially large data size of this context provider, deploying Shasta locally without GPU acceleration may lead to slow performance. Therefore, it is recommended to deploy Shasta locally with GPU or use the remotely deployed KrugleAI Base Pro service on a GPU instance for faster inference speed and improved performance.
>
##### File Tree

Type `@tree` to reference the hierarchical structure of your current workspace. This will allow the LLM to view the nested directory layout of your project.

> Note: Due to the potentially large data size of this context provider, deploying Shasta locally without GPU acceleration may lead to slow performance. Therefore, it is recommended to deploy Shasta locally with GPU or use the remotely deployed KrugleAI Base Pro service on a GPU instance for faster inference speed and improved performance.

##### URL

Type `@url` and enter a URL. KLiP will then convert it into a Markdown document for the model.

```json
{ "name": "url" }
```

##### Documentation

To index and retrieve snippets from any documentation site, type `@docs`.

```json
{ "name": "docs" }
```

**Add a Single Documentation Site**

To add a single documentation site, we recommend using the `@docs` context provider. Select "Add Docs" from the dropdown, then enter the site's root URL and a title for reference. Indexing may take some time.

![](docs.png)

Once the site is indexed, type `@docs`, select your documentation from the dropdown, and KLiP will automatically use similarity search to find relevant sections for your query.

<img width="500" alt="image" src="docs2.png">

![](docs3.png)

Clicking the used context will reveal the source documentation.

<img width="1065" alt="image" src="docs4.png">

KLiP also pre-indexes a number of common documentation sites. These sites' embeddings are hosted by us and downloaded locally after the first request. All other indexing occurs entirely locally. Ensure the domain `krugle-klip.s3.ap-northeast-1.amazonaws.com` is whitelisted in your firewall.

**Add Multiple Documentation Sites via config.json**

To add multiple documentation sites, you can update your `config.json` file. Indexing will start when the file is saved.

Update the `config.json` file as shown:

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

- `title`: The name of the documentation site, used for identification in the UI.
- `startUrl`: The URL where the indexing process begins.
- `rootUrl`: The base URL of the site, used to determine which pages to index.
- `faviconUrl`: The site's favicon URL, used for visual identification in the UI.

Documentation is indexed automatically when the configuration file is updated, unless indexing is disabled. To manually trigger indexing, use the command `Klip: Docs Index` in the VSCode command panel (press `Shift + Cmd/Ctrl + P`). To force indexing, use `Klip: Docs Force Re-Index`. These commands work even if automatic indexing is turned off.

<img width="560" alt="image" src="docs5.png">

**Crawling Dynamically Generated Sites**

By default, we use a lightweight tool to crawl documentation sites that don't require JavaScript rendering.

If you need to crawl a site that's dynamically generated, or if you encounter an error, you can enable the experimental `useChromiumForDocsCrawling` feature in your `config.json`. This will download and install Chromium in the KLiP cache directory.

```json
"experimental": {
  "useChromiumForDocsCrawling": true
}
```

##### Terminal

Use `@terminal` to access the contents of your IDE's terminal.

```json
{ "name": "terminal" }
```

##### GitHub Issues

Type `@issue` to directly reference conversations within GitHub issues. Make sure to include your own [GitHub personal access token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token) to avoid rate limiting:

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

##### GitLab Merge Request

Type `@gitlab-mr` to reference an open merge request (MR) for the current branch on GitLab.

**Configuration**

Create a [personal access token](https://docs.gitlab.com/ee/user/profile/personal_access_tokens.html) with the `read_api` scope, then add the following to your configuration:

```json
{
  "name": "gitlab-mr",
  "params": {
    "token": "..."
  }
}
```

**Using Self-Hosted GitLab**

To communicate with a self-hosted GitLab instance, set the `domain` parameter in your configuration. By default, this is set to `gitlab.com`.

```json
{
  "name": "gitlab-mr",
  "params": {
    "token": "...",
    "domain": "gitlab.example.com"
  }
}
```

**Filtering Comments**

If you're editing specific code, you can filter out comments from other files by setting `filterComments` to `true`.

##### Jira Issues

Type `@jira` to reference the conversation in a Jira issue. Be sure to include your own [Atlassian API Token](https://id.atlassian.com/manage-profile/security/api-tokens), or use your `email` and `token`, with the token set as your password for basic authentication. If you're using your own Atlassian API Token, do not configure your email.

```json
{
  "name": "jira",
  "params": {
    "domain": "company.atlassian.net",
    "token": "ATATT..."
  }
}
```

**Jira Datacenter Support**

This context provider supports both Jira API versions 2 and 3. By default, it uses version 3 (the cloud version), but if you are using the Jira datacenter version, you'll need to set the API Version to 2 using the `apiVersion` property.

```json
  "params": {
    "apiVersion": "2",
    ...
  }
```

**Issue Query**

By default, the following query is used to find issues:

```
assignee = currentUser() AND resolution = Unresolved order by updated DESC
```

You can override this query by setting the `issueQuery` parameter.

##### Operating System

Type `@os` to reference your current operating system's architecture and platform.

```json
{ "name": "os" }
```

##### Codebase Skeleton

Provides an overview of all files in the codebase or a subfolder, highlighting the key symbols of top-level classes, functions, and methods in each file. It includes the critical lines of code where these symbols are defined, helping the model better understand how each piece of code connects to the overall codebase.

```json
{
  "name": "skeleton",
  "params": {}
}
```

##### PostgreSQL - Work in Progress, Coming Soon

To reference the schema of a table along with sample rows, type `@postgres`.

##### Database Tables - Work in Progress, Coming Soon

Type `@database` to reference table schemas. You can use the drop-down menu or begin typing table names based on your configuration.

##### Debugger: Local Variables - Work in Progress, Coming Soon

Type `@local`s to reference the local variables within the top n levels (defaulting to 3) of the call stack for that thread.

##### Requesting Context Providers

If you don't find what you need, reach out to the Krugle support team or create an issue [here](https://github.com/krugle2/Klip/issues/new) to request a new ContextProvider.

### Slash Commands

Slash commands are shortcuts activated by typing '/' and selecting from the dropdown. For instance, the built-in `/edit` slash command enables you to stream edits directly into your editor.

<img width="451" alt="image" src="slash.png">

#### Built-in Slash Commands

To use any of the built-in slash commands, open config.json and add it to the `slashCommands` list.

##### /edit

Select code with `cmd/ctrl + L`, then type "/edit" followed by instructions for the edit. KLiP will stream the changes into a side-by-side diff editor.

```json
{
  "name": "edit",
  "description": "Edit highlighted code"
}
```

##### /comment

`/comment` functions similarly to `/edit`, except it automatically prompts the LLM to comment the code.

```json
{
  "name": "comment",
  "description": "Write comments for the highlighted code"
}
```

##### /share

Type "/share" to generate a shareable markdown transcript of your current chat history.

```json
{
  "name": "share",
  "description": "Download and share this session"
}
```

##### /cmd

Generate a shell command from natural language and (only in VS Code) automatically paste it into the terminal.

```json
{
  "name": "cmd",
  "description": "Generate a shell command"
}
```

##### /commit

Displays your current git diff to the LLM and asks it to generate a commit message.

```json
{
  "name": "commit",
  "description": "Generate a commit message for the current changes"
}
```

#### Custom Commands Using Natural Language (DEPRECATED)

> This feature is deprecated, use Prompt Customization feature instead

You can add custom slash commands by appending to the `customCommands` property in `config.json`.

- `name`: the name of the command, which will be invoked with `/name`
- `description`: a brief command description shown in the dropdown
- `prompt`: instructions to the LLM displayed in the prompt

Custom commands are useful for frequent reuse of a prompt. For example, if you've crafted a prompt for checking mistakes in your code, you could add a command like this:

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

### Why KLiP is not activated?

#### Invalid credentials for

If your Krugle Enterprise server enables authentication, and you see the error `Invalid credentials for aaa. Please check your username，re-enter your password` from KLiP. e.g.

![](faq1.png)

It means your Krugle Enterprise credentials are incorrect. Please verify your username on the KLiP VSCode settings page and re-enter your password.

If your Krugle Enterprise server does not require authentication, leave the username field blank.

![](faq2.png)

### Why KLiP keeps outputting garbled text

Please start by examining the `shasta.log` file. On macOS or Windows, you can locate it at `$SHASTA_HOME/shasta.log`. While on Linux, the location is `/var/log/shasta/shasta.log`. If you encounter the errors listed below, it indicates insufficient RAM on your machine.

```log
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
ggml_metal_graph_compute: command buffer 3 failed with status 5
```

**Solution:**

Adjust the `contextLength` and `maxTokens` parameters in your KLiP config.json file. Here are some example value pairs: `16384/4096`, `8192/4096`, `8192/2048`, `4096/2048`, `2048/1024`, `2048/512`, `1024/512`.

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

### Why doesn't  Shasta always use all CPU cores?

Simply add the `numThreads` option.

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

### Why doesn't Shasta always use the GPU?

Shasta uses dedicated GPU (NVIDIA/AMD) VRAM for inference. The CPU is always required because tasks like loading model parameters still need to read the model file into RAM before transferring it to VRAM.

#### 100% GPU Usage

```text
krugle-code-10b:latest c1669e6bec24 10 GB 100% GPU
```

All model weights are loaded into VRAM. The next factor is the context window size.

If there's enough available VRAM to handle the context window size, the GPU will be used. If not, the CPU will handle the inference.

The context window size can be adjusted on the client side (AI Core or KLiP). For example, you can reduce the `contextLength` in KLiP by modifying the `config.json`:

```json
{
  "title": "KrugleAI Code 10B",
  "model": "krugle-code-10b",
  "apiBase": "http://localhost:5668",
  "contextLength": 16384,
  "template": "krugle-10b-en",
  "completionOptions": {
    "temperature": 0.7,
    "topK": 45,
    "topP": 0.75,
    "maxTokens": 4096
  },
  "provider": "krugle-shasta"
}
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

### Completions are slow

This depends on your hardware.

### Completions don't know about my code

We are working on improving the accuracy of this system and expect significant improvements in the coming weeks.

### Completions contain formatting errors

If you notice a recurring pattern of mistakes, please report it to us. We will address and fix it as soon as possible.

### Why Quick Lens Tools are not shown?

You must have the [Language Server Protocol](https://microsoft.github.io/language-server-protocol/) extension installed for the language of the file you have open. If your VSCode lacks Language Server Protocol support for the language, search for "Language Server Protocol" in the VSCode extension marketplace.

---

License

[© 2024 Krugle/Aragon Consulting Group, Inc.](https://krugle.co.jp)
