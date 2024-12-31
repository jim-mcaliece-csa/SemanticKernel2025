# Semantic Kernel Proof of Concepts

This repository demonstrates several Proof of Concepts (PoCs) leveraging Microsoft's [Semantic Kernel](https://github.com/microsoft/semantic-kernel). The projects explore its capabilities in AI development, orchestration, and integration with Azure OpenAI and other tools.

## Table of Contents

- [About Semantic Kernel](#about-semantic-kernel)
- [Setup](#setup)
- [Proof of Concepts](#proof-of-concepts)
  - [1. Natural Language Processing (NLP)](#1-natural-language-processing-nlp)
  - [2. Contextual Memory](#2-contextual-memory)
  - [3. Task Orchestration](#3-task-orchestration)
  - [4. Azure Integration](#4-azure-integration)
  - [5. Chatbot Development with RAG](#5-chatbot-development-with-rag)
- [How to Run](#how-to-run)
- [Contributing](#contributing)
- [License](#license)

---

## About Semantic Kernel

Semantic Kernel is an open-source framework for integrating AI services into applications. It provides tools for orchestrating AI models like GPT, embedding models, and traditional programming functions in a cohesive system.

This repository demonstrates how to use Semantic Kernel's:

- Plugins
- Memory storage
- Context management
- Extensibility with external APIs

For more information, visit the [official Semantic Kernel GitHub repository](https://github.com/microsoft/semantic-kernel).

---

## Setup

1. **Clone this repository:**
   ```bash
   git clone https://github.com/jim-mcaliece-csa/SemanticKernel2025.git
   cd SemanticKernel2025
   ```

2. **Set up Azure OpenAI:**
   - Obtain your Azure OpenAI resource endpoint and API key.
   - Add your credentials to the `appsettings.json` file:
     ```json
     {
         "AzureOpenAI": {
             "ApiKey": "your-api-key",
             "Endpoint": "https://your-endpoint.openai.azure.com/"
         }
     }
     ```

3. **Build the project:**
   Open the solution in Visual Studio or your preferred C# IDE and build the project to restore dependencies.

4. **Run the application:**
   Start the application from your IDE or using the .NET CLI:
   ```bash
   dotnet run
   ```

---

## Proof of Concepts

### 1. Natural Language Processing (NLP)

**Description:** Demonstrates how Semantic Kernel can execute complex NLP tasks such as text summarization, language translation, and sentiment analysis.

**Code Examples:** Located in the `poc/nlp` directory.

---

### 2. Contextual Memory

**Description:** Implements long-term and short-term memory storage using Semantic Kernel's memory system for enhanced conversational AI experiences.

**Code Examples:** Located in the `poc/memory` directory.

---

### 3. Task Orchestration

**Description:** Explores how to chain AI tasks together using Semantic Kernel, allowing dynamic workflows and decision-making.

**Code Examples:** Located in the `poc/orchestration` directory.

---

### 4. Azure Integration

**Description:** Shows seamless integration with Azure services, including Azure Cognitive Services and Azure OpenAI.

**Code Examples:** Located in the `poc/azure_integration` directory.

---

### 5. Chatbot Development with RAG

**Description:** Demonstrates the Retrieval-Augmented Generation (RAG) pattern for building a chatbot using Azure OpenAI, Semantic Kernel, and external data sources.

**Code Examples:** Located in the `poc/chatbot_rag` directory.

---

## How to Run

1. Navigate to the specific PoC directory.
   ```bash
   cd poc/<poc-name>
   ```

2. Run the application associated with the PoC:
   ```bash
   dotnet run
   ```

3. Follow the instructions provided in the terminal.

---

## Contributing

We welcome contributions! Please fork the repository, create a branch, and submit a pull request.

### Steps:
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes and commit them:
   ```bash
   git commit -m "Add your feature description"
   ```
4. Push your changes:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Open a pull request.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Happy coding! 🚀
