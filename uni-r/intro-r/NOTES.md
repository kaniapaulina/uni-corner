# Intro-R

# Lab 1: Vectors and Lists

## Vectors - Core Concepts

**Vectors** are R's basic data structure: one-dimensional arrays holding elements of the same type (numeric, character, logical).

Key features: atomic (same type), vectorized operations, indexing with `[]`

### Creating Vectors

```r
# Combine values and sequences
a1 <- c(55, 22, 1:200, 13)

# Repetition patterns
b1 <- rep(c(4, 6, 3), times = 10)     # Repeat entire sequence
c1 <- rep(3:9, each = 3)               # Repeat each element
c2 <- rep(c(4, 6, 3), times = c(10, 20, 30))  # Variable repetitions

# Regular sequences
d1 <- seq(-5, 5, length.out = 100)     # Even spacing
seq(100, 4, by = -8)                   # Custom steps

# Random sampling
set.seed(111)                          # Reproducibility
e1 <- sample(1:99, 30)                 # 30 unique numbers
f1 <- sample(c(0, 1), 99, replace = TRUE, prob = c(0.3, 0.7))  # Weighted
```

### Vector Operations

```r
# Element-wise operations (vectorized)
res <- exp(x) * cos(y)

# Index shifting (time series)
y[2:150] - x[1:149]                    # y[i] - x[i-1]

# Series summations
i_seq <- 10:100
sum(i_seq^3 + 4 * i_seq^2)

# Double summations (vectorized alternative to nested loops)
i_vals <- rep(1:20, each = 5)
j_vals <- rep(1:5, times = 20)
sum((2^i_vals / i_vals) + (3^j_vals / j_vals))
```

### Filtering and Indexing

```r
# Logical indexing
vals_gt_60 <- y[y > 60]                # Values
idx_gt_60 <- which(y > 60)             # Indices
x_matching <- x[y > 60]                # Parallel vector

# Sorting and selection
x[order(y)]                            # Sort x by y's order
y[seq(1, length(y), by = 3)]          # Every 3rd element

# Logical functions
any(vec > 95)                          # At least one TRUE
all(vec > 85)                          # All TRUE

# Modulo operations
sum(x %% 2 == 0)                       # Count even numbers
sum(x %% 6 == 0)                       # Divisible by 2 AND 3
```

### Advanced Operations

```r
# Cumulative products
nums <- seq(2, 38, by = 2)
dens <- seq(3, 39, by = 2)
1 + sum(cumprod(nums / dens))

# Probability distributions
runif(500, 3, 5)                       # Uniform [3,5]
rnorm(500)                             # Standard normal N(0,1)

# Visualization
par(mfrow = c(1, 2))                   # 1x2 plot layout
hist(x, col = "lightblue")
boxplot(y, col = "lightgreen")
par(mfrow = c(1, 1))                   # Reset

# String operations
paste("label", 1:50)                   # With spaces
paste0("fn", 1:50)                     # Without spaces
paste0(rep(c("A", "X"), 15), "_", 1:30, ".", rep(c("B", "D", "F"), 10))
```

### Text Analysis

```r
# Character vectors
letters                                # a-z
LETTERS                                # A-Z
sample(c(letters, LETTERS), 100, replace = TRUE)

# String analysis
napis <- c("Katedra", "Informatyki", "Biznesowej")
length(napis)                          # Number of elements
nchar(napis)                           # Characters per element
class(napis)                           # Type

# Advanced text processing
znaki <- unlist(strsplit(as.character(napis), ""))
length(unique(znaki))                  # Unique characters
names(which.max(table(znaki)))         # Most frequent
```

## Lists

**Lists** are flexible structures containing elements of different types and sizes.

```r
# Creating and accessing
xlist <- list(a = c(2,3,5), b = c("aa","bb"), c = c(TRUE, FALSE))
xlist[2:3]                             # Returns list
xlist[[2]]                             # Returns content
xlist$a                                # Named access
xlist[-2]                              # Exclude element

# Modifying
names(xlist) <- c("V1", "V2", "V3")
xlist$V4 <- 1:10                       # Add element

# Apply functions
l1 <- lapply(1:6, function(n) runif(n, 2, 8))  # Apply to each
mapply("+", l1, l2)                    # Parallel operation
```

---

# Lab 2: Matrices and Data Frames

## Matrices

**Matrices** are 2D arrays with same-type elements. Access: `matrix[row, col]`

```r
# Create and summarize
A <- matrix(sample(-20:20, 200, replace = TRUE), nrow = 20, ncol = 10)
colSums(A)                             # Column sums
rowMeans(A)                            # Row means

# apply() function: apply(data, margin, function)
apply(A, 2, max)                       # Max per column (margin=2)
apply(A, 1, sd)                        # SD per row (margin=1)

# Special structures
B <- matrix(0, n, n)
diag(B) <- 1:n                         # Main diagonal
B[cbind(1:n, n:1)] <- 1:n             # Anti-diagonal

# Matrix operations
t(C) %*% D                             # Transpose × multiply
crossprod(t(C), t(D))                  # Efficient alternative
outer(0:9, 0:9, function(a,b) (a+b) %% 10)  # Pairwise operations

# Missing data
x[sample(length(x), 20)] <- NA
mean(x, na.rm = TRUE)                  # Ignore NA
is.na(x)                               # Check for NA

# Row-wise operations
t(apply(G, 1, function(x) sort(x, decreasing=TRUE)[1:2]))  # Top 2 per row
```

### Lists of Matrices

```r
# Generate multiple matrices
dims <- sample(2:10, 10, replace = TRUE)
x_list <- lapply(1:10, function(i) 
  matrix(rnorm(dims[i]^2, mean=means[i], sd=sds[i]), nrow=dims[i]))

lapply(x_list, dim)                    # Dimensions
sapply(x_list, det)                    # Determinants (simplified output)
```

## Data Frames

**Data frames** are tables with columns of different types (like database tables/spreadsheets).

```r
# Create
dane <- data.frame(cs = cs, cp = cp, odp = odp, wn = wn, pun = pun, gr = gr)
head(dane, 10)

# Add columns/rows
dane$daty <- seq(as.Date("2025-07-06"), by = "day", length.out = 101)
dane <- rbind(dane, new_row)           # Row bind
dane <- cbind(dane, new_col)           # Column bind

# Filter and subset
dane[which(dane$odp == "nie_wiem" & dane$wn > 60), ]
subset(dane, wiek > 20 & adres %in% c("Kraków", "Warszawa"), 
       select = c("wiek", "adres"))

# Aggregation
aggregate(cs ~ gr, data = dane, mean)  # Mean by group
tapply(dane$obrot, dane$nazwa, sum)    # Sum by group (named vector)

# Pivot tables (reshape2)
library(reshape2)
dcast(dane, gr ~ odp, value.var = "pun", fun.aggregate = mean)

# Data quality
complete.cases(dane)                   # Rows without NA
duplicated(dane)                       # Duplicate rows
table(dane$wiek)                       # Frequency counts
```

---

# Lab 3: Reading Data & External Sources

## Reading Files

```r
# CSV files
dane <- read.csv("market.csv", header = TRUE, sep = ",")
nrow(dane)                             # Row count
sum(dane$cena * dane$ilosc)           # Calculations

# From URLs
danezloto <- read.csv("https://stooq.pl/q/d/l/?s=xaupln&...")
danezloto$Data <- as.Date(danezloto$Data)

# Missing data analysis
sum(is.na(d2))                         # Count NA
dd2 <- d2[d2$geo == "Poland" & d2$sex == "Total", ]
mean(dd2$OBS_VALUE, na.rm = TRUE)

# Aggregation (most traded companies)
sort(table(dane$nazwa), decreasing = TRUE)[1:3]
sort(tapply(dane$obrot, dane$nazwa, sum), decreasing = TRUE)[1:3]
```

## Time Series

```r
library(zoo)

# Time-based aggregation
dane$YM <- as.yearmon(dane$Data)
aggregate(Zamkniecie ~ YM, data = dane, FUN = mean)

# ts objects
wig20_ts <- ts(d4$Zamkniecie, start = c(2024, 1), frequency = 12)
plot(wig20_ts, col = "red", lwd = 2)
abline(v = floor(time(wig20_ts)), col = "lightgrey", lty = "dotted")

# Moving average
wig20_ma <- stats::filter(wig20_ts, rep(1/6, 6), sides = 2)
lines(wig20_ma, col = "darkblue", lty = "dashed", lwd = 2)
```

## Financial Data

```r
library(quantmod)
getSymbols(c("^GSPC", "AAPL"), src = 'yahoo', 
           from = "2024-01-02", to = "2025-06-02")
mean(Cl(AAPL))                         # Closing prices
# Also: Op(), Hi(), Lo(), Vo()
```

## Visualization

```r
# Multiple plots
par(mfcol = c(2, 1))                   # Stack vertically
hist(x, freq = FALSE)                  # Density histogram
boxplot(x, horizontal = TRUE)
par(mfcol = c(1, 1))                   # Reset
```

---

# Web Scraping with rvest

```r
library(rvest)
library(dplyr)
library(stringr)

# Scrape table
url <- "https://en.wikipedia.org/wiki/..."
page <- read_html(url)
tables <- page %>% html_table(fill = TRUE)
data <- tables[[2]]

# Clean data (pipe operator %>%)
sales_data <- data %>%
  select(Title, Copies.sold) %>%
  mutate(Rank = row_number(),
         Copies_M = as.numeric(str_replace_all(Copies.sold, "[^0-9.]", ""))) %>%
  filter(Rank <= 100) %>%
  arrange(Rank)

# Group and aggregate
summary <- sales_data %>%
  mutate(Group = cut(Rank, breaks = c(0, 10, 20, 30, 100),
                     labels = c("1-10", "11-20", "21-30", "31-100"))) %>%
  group_by(Group) %>%
  summarise(Mean_Sales = mean(Copies_M, na.rm = TRUE), .groups = 'drop')

# Visualize with ggplot2
library(ggplot2)
ggplot(summary, aes(x = Group, y = Mean_Sales)) +
  geom_bar(stat = "identity", fill = "#e60012") +
  geom_text(aes(label = sprintf("%.2fM", Mean_Sales)), vjust = -0.5) +
  labs(title = "Average Sales", x = "Rank Group", y = "Sales (millions)") +
  theme_minimal()
```

**Key dplyr/tidyr functions:**

- `%>%`: pipe operator (chains operations)
- `mutate()`: create/modify columns
- `filter()`: keep rows matching condition
- `select()`: choose columns
- `group_by()` + `summarise()`: aggregate by groups
- `cut()`: bin continuous variables

---

# R Markdown & Presentations

**R Markdown** combines markdown text + R code → multiple outputs (HTML, PDF, presentations)

### Document Structure

```yaml
---
title: "Title"
author: "Author"
output: ioslides_presentation
---
```

### Code Chunks

**Chunk options:** `echo` (show code), `eval` (run code), `include` (show output), `fig.width/height`, `message`, `warning`

### Slides & Formatting

```markdown
## Slide Title { .custom-class }

Content here

## Two Columns | Subtitle
<div class="columns-2">
### Col 1
Content
### Col 2  
Content
</div>

![Caption](image.png){width=250px}

$\dot{x} = \pi t^2$                    <!-- Inline math -->
$$\dot{x} = \sigma(y-x)$$              <!-- Block math -->
```

### Display Options

```r
summary(x)                             # echo=F: output only
```

```
summary(x)                             # echo=T: code + output
```

```
summary(x)                             # eval=F: code only
```

---

# Lab 6: Writing Functions

```r
# Function structure
function_name <- function(param1, param2 = default) {
  # Validation
  stopifnot(is.numeric(param1))
  if (condition) stop("Error message")
  
  # Body
  result <- computation
  return(result)  # or just result (last expression)
}
```

## Example Functions

```r
# Statistical function
minmaxK <- function(x, K = 5) {
  stopifnot(is.numeric(x))
  if (length(x) < K) return("Error: vector too short")
  list(Min = sort(x)[1:K], Max = sort(x, decreasing=TRUE)[1:K])
}

# Normalization [0,1]
myNorm <- function(x, na.rm = FALSE) {
  min_x <- min(x, na.rm = na.rm)
  max_x <- max(x, na.rm = na.rm)
  if (max_x == min_x) return(rep(0, length(x)))
  (x - min_x) / (max_x - min_x)
}

# Correlations
myCorr <- function(x, y) {
  if (length(x) != length(y)) stop("Vectors must be same length")
  c(Pearson = cor(x, y, "pearson"),
    Kendall = cor(x, y, "kendall"),
    Spearman = cor(x, y, "spearman"))
}

# Flexible statistics
myStats <- function(x, p = 0) {
  if (p == 0) c(Mean = mean(x), SD = sd(x))              # Parametric
  else c(Median = median(x), MAD = mad(x))               # Non-parametric
}
```

## Root Finding

```r
# Single root
myFun <- function(x) 10*sin(1.5*x)*cos(0.5*x^3) + 0.5*sqrt(abs(x))
uniroot(myFun, c(6, 7))$root

# All roots
library(rootSolve)
curve(myFun, -3, 3)
abline(h = 0, lty = 2)
roots <- uniroot.all(myFun, c(-3, 3))
points(roots, rep(0, length(roots)), col = "red", pch = 19)

# Systems of equations
mySystem <- function(x) {
  c(2*x[1] + x[2] - 2*x[3] + 2,
    x[1] + 2*x[2] - 2*x[3] - 1,
    2*x[1] + x[2] - x[3] + 3)
}
multiroot(mySystem, start = c(1, 1, 1))$root
```

---

# Shiny Applications

**Shiny** creates interactive web apps with R.

**Architecture:** UI (layout/inputs) + Server (reactive logic/outputs)

## Basic Template

```r
library(shiny)

ui <- fluidPage(
  titlePanel("App Title"),
  sidebarLayout(
    sidebarPanel(
      sliderInput("bins", "Bins:", min = 1, max = 50, value = 30),
      selectInput("var", "Variable:", choices = names(data)),
      checkboxInput("smooth", "Show smoothed", value = FALSE),
      radioButtons("type", "Type:", choices = list("A" = 1, "B" = 2)),
      dateRangeInput('dates', 'Date range:')
    ),
    mainPanel(
      plotOutput("plot"),
      verbatimTextOutput("summary"),
      tableOutput("table")
    )
  )
)

server <- function(input, output) {
  # Reactive expressions
  data_filtered <- reactive({
    filter_data(input$var, input$dates)
  })
  
  # Outputs
  output$plot <- renderPlot({
    hist(data_filtered(), breaks = input$bins)
  })
  
  output$summary <- renderPrint({
    summary(data_filtered())
  })
  
  output$table <- renderTable({
    head(data_filtered())
  })
}

shinyApp(ui, server)
```

## Key Concepts

**Reactive expressions:** `reactive({...})` - computed values that update when inputs change

**Render functions:** 

- `renderPlot({...})` → `plotOutput()`
- `renderText({...})` → `textOutput()`
- `renderPrint({...})` → `verbatimTextOutput()`
- `renderTable({...})` → `tableOutput()`
- `renderDT({...})` → `DTOutput()` (interactive tables with DT package)

**Access patterns:**

- Inputs: `input$name`
- Outputs: `output$name`
- Reactive values: `reactive_expr()` (with parentheses!)

## Conditional Rendering

```r
output$plot <- renderPlot({
  if (input$show_original) {
    plot(data, type = "l")
    if (input$show_smooth) lines(smooth_data, col = "red")
  } else if (input$show_smooth) {
    plot(smooth_data, type = "l", col = "red")
  }
})
```

## Tab Panels

```r
navbarPage("App Name",
  tabPanel("Tab 1", ...),
  tabPanel("Tab 2", ...),
  navbarMenu("More",
    tabPanel("Sub 1", ...),
    tabPanel("Sub 2", ...)
  )
)
```

## Styling

```r
library(shinyWidgets)
setBackgroundColor(color = c("#ebf0fa", "white"), 
                   gradient = "linear", direction = "left")
includeCSS("custom.css")
```

---