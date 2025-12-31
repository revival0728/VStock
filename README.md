# VStock - 股票分析可視化工具

一個功能強大的 Windows Forms 應用程式，提供實時和歷史股票數據分析、技術指標計算以及獨特的視覺化表現方式。

## 📋 目錄

- [功能特色](#功能特色)
- [快速開始](#快速開始)
- [使用說明](#使用說明)
- [技術架構](#技術架構)
- [依賴項目](#依賴項目)
- [項目結構](#項目結構)

## 🎯 功能特色

### 1. **實時股票查詢**
- 查詢當前股票實時價格和交易數據
- 支持批量查詢多檔股票
- 獲取最新的開盤價、最高價、最低價、收盤價和交易量

### 2. **歷史數據分析**
- 獲取指定日期範圍內的歷史股票數據
- 自動過濾不完整或異常數據
- 支持自定義查詢時間段

### 3. **傳統技術指標分析 (TradSPage)**
支持多種技術分析指標的計算和可視化：
- **SMA (Simple Moving Average, 簡單移動平均)**
  - 可自定義窗口大小
  - 支持多條不同週期的均線
  
- **Bollinger Bands (布林帶)**
  - 上下軌線顯示
  - 中線（SMA）對應
  
- **RSI (Relative Strength Index, 相對強弱指標)**
  - 超買/超賣水平線 (70/30)
  - 動態範圍顯示
  
- **MACD (Moving Average Convergence Divergence, 指數平滑異同移動平均線)**
  - 信號線、柱狀圖
  - 動量分析

### 4. **VStock 視覺化分析 (VStockSPage)**
創新的矩陣視覺化方式，將股票數據轉換為彩色矩陣圖像：
- **噪聲圖生成**: 基於股票數據的多色矩陣視覺化
- **色階圖生成**: 基於股票數據的單色矩陣視覺化
- RGB 色彩通道分解
- 矩陣運算和數據映射

## 🚀 快速開始

### 系統需求
- Windows OS
- .NET 8.0 或更高版本
- 網路連接（用於下載股票數據）

### 安裝和運行

1. **克隆或下載專案**
```bash
git clone <repository-url>
cd VStock
```

2. **編譯專案**
```bash
dotnet build
```

3. **運行應用程式**
```bash
dotnet run
```

## 📖 使用說明

### 主頁 (HomePage)

#### 搜索設置
1. **輸入股票代碼**: 在「股票代碼」輸入框中輸入股票符號（例：AAPL, MSFT）
2. **添加到清單**: 點擊「新增」按鈕將股票添加到搜索清單
3. **移除清單項**: 選中項目後點擊「刪除」按鈕

#### 查詢模式選擇
- **實時查詢**: 選擇此選項獲取當前市場數據
- **歷史查詢**: 
  - 選擇此選項啟用日期範圍選擇
  - 設置「開始日期」和「結束日期」
  - 注意：歷史查詢不支持多檔股票同時查詢

#### 分析方式選擇
- **傳統查詢分析**: 使用標準技術指標（SMA、BB、RSI、MACD）進行分析
- **VStock 查詢分析**: 使用矩陣視覺化方式進行創新分析

### 傳統分析頁面 (TradSPage)

1. **選擇指標**: 在左側勾選要顯示的技術指標
   - SMA（簡單移動平均）
   - BB（布林帶）
   - RSI（相對強弱指標）
   - MACD（指數平滑異同移動平均線）

2. **配置參數**:
   - 調整指標的計算參數（如 SMA 週期）
   - 設置視覺化選項

3. **查看圖表**: 右側會實時顯示股票價格走勢和技術指標

### VStock 分析頁面 (VStockSPage)

1. **生成視覺化圖像**:
   - 點擊「生成噪聲圖」：基於股票數據生成多色矩陣視覺化
   - 點擊「生成色階圖」：基於股票數據生成多色矩陣視覺化

2. **觀察圖像模式**:
   - 颜色變化代表不同的數據值
   - 圖像模式反映數據的特性和分佈

## 🔧 技術架構

### 核心類別結構

#### `Stock` - 股票數據模型
- **屬性**:
  - `Date`: 交易日期
  - `Open`: 開盤價
  - `High`: 最高價
  - `Low`: 最低價
  - `Close`: 收盤價
  - `Volume`: 交易量
- **功能**:
  - 實現 `IQuote` 接口（用於技術指標計算）
  - 轉換為 `OHLC` 格式用於 ScottPlot 繪製

#### `Crawler` - 數據爬蟲類
- **方法**:
  - `GetRealTime(List<string>)`: 獲取實時股票數據
  - `GetHistorical(string, DateTime, DateTime)`: 獲取歷史股票數據
- **特性**:
  - 使用 Yahoo Finance API
  - 自動過濾異常數據（High ≈ Low 的情況）

#### `Matrix` - 矩陣運算類
- **功能**:
  - 二維整數矩陣操作
  - 矩陣初始化（全 1 矩陣）
  - 矩陣元素訪問和修改
  - 模運算支持

#### `HomePage` - 主窗口
- **功能**:
  - 股票搜索界面
  - 查詢模式選擇（實時/歷史）
  - 分析方式選擇（傳統/VStock）
  - 異步數據獲取和頁面切換

#### `TradSPage` - 傳統技術分析頁面
- **功能**:
  - 計算和繪製 SMA、BB、RSI、MACD
  - 使用 ScottPlot 進行高性能圖表繪製
  - 支持交互式圖表操作

#### `VStockSPage` - VStock 視覺化分析頁面
- **功能**:
  - RGB 矩陣數據管理
  - 噪聲圖生成（多色矩陣）
  - 色階圖生成（單色矩陣）
  - 圖像像素繪製

## 📦 依賴項目

### NuGet 包

| 包名稱 | 版本 | 用途 |
|--------|------|------|
| **ScottPlot.WinForms** | 5.1.57 | 高性能股票圖表繪製 |
| **Skender.Stock.Indicators** | 2.7.0 | 技術指標計算（SMA、BB、RSI、MACD） |
| **YahooFinanceApiNext** | 2.3.10 | Yahoo Finance 股票數據 API |

### 系統依賴
- .NET 8.0 Windows 運行時
- Windows Forms 框架
- System 命名空間（基礎功能）

## 📁 項目結構

```
VStock/
├── Program.cs                          # 應用程式入口點
├── HomePage.cs / HomePage.Designer.cs  # 主窗口和 UI 設計
├── TradSPage.cs / TradSPage.Designer.cs # 傳統技術分析頁面
├── VStockSPage.cs / VStockSPage.Designer.cs # VStock 視覺化頁面
├── Stock.cs                            # 股票數據模型
├── Crawler.cs                          # 數據爬蟲（Yahoo Finance）
├── Matrix.cs                           # 矩陣運算類
├── VStock.csproj                       # 專案配置文件
├── HomePage.resx                       # UI 資源文件
├── TradSPage.resx                      # UI 資源文件
└── VStockSPage.resx                    # UI 資源文件
```

## 🔐 API 說明

### Crawler 類 API

#### `GetRealTime(List<string> stockIds)`
```csharp
// 獲取實時股票數據
List<Stock> stocks = await Crawler.GetRealTime(new List<string> { "AAPL", "MSFT" });
```

**參數**:
- `stockIds`: 股票代碼列表

**返回值**:
- 包含實時股票數據的 `List<Stock>`

**異常**:
- 網路連接失敗時拋出異常

#### `GetHistorical(string stockId, DateTime from, DateTime to)`
```csharp
// 獲取歷史股票數據
DateTime startDate = new DateTime(2024, 1, 1);
DateTime endDate = new DateTime(2024, 12, 31);
List<Stock> history = await Crawler.GetHistorical("AAPL", startDate, endDate);
```

**參數**:
- `stockId`: 單個股票代碼
- `from`: 開始日期
- `to`: 結束日期

**返回值**:
- 包含歷史股票數據的 `List<Stock>`（已過濾異常數據）

## 🎨 技術指標詳解

### SMA (簡單移動平均)
- **計算**: 最近 N 天收盤價的平均值
- **用途**: 識別趨勢方向
- **常用週期**: 20、50、200 天

### Bollinger Bands (布林帶)
- **組成**: 中線 (SMA) ± 標準差
- **用途**: 識別超買/超賣狀態
- **默認參數**: 20 日周期，2 個標準差

### RSI (相對強弱指標)
- **範圍**: 0-100
- **訊號**: 
  - > 70: 超買
  - < 30: 超賣
  - 用於反轉信號
  
### MACD (指數平滑異同移動平均線)
- **組成**: 快速線、慢速線、信號線、柱狀圖
- **訊號**: 
  - 快速線穿過慢速線：買入/賣出信號
  - 柱狀圖反映動量強度

## 💡 開發建議

### 擴展功能
1. **添加更多指標**: 在 `TradSPage` 中添加新的技術指標計算和繪製
2. **支持更多數據源**: 擴展 `Crawler` 類以支持其他 API
3. **增強視覺化**: 改進 `VStockSPage` 的矩陣運算和圖像生成算法
4. **數據持久化**: 添加本地數據庫存儲歷史查詢結果

### 性能優化
- 使用非同步操作避免 UI 凍結
- 緩存已下載的數據

## 🧠 ProTips
- 生成的噪聲圖可用於 DDPM 的 AI 模型

## 📝 許可證
參見 [LICENSE.txt](LICENSE.txt) 文件

## 🤝 貢獻
歡迎提交 Issue 和 Pull Request 來改進本專案！