items = [
  { name: "#1", weight: 1, profit: 4 },
  { name: "#2", weight: 3, profit: 9 },
  { name: "#3", weight: 5, profit: 12 },
  { name: "#4", weight: 4, profit: 11 },
];

max_weight = 8;

let dp = [];

items.splice(0, 0, { name: "#0", weight: 0, profit: 0 });

for (let i = 0; i < items.length; i++) {
  dp[i] = [];
  for (let j = 0; j <= max_weight; j++) {
    if (i == 0 || j == 0) {
      dp[i][j] = 0;
    } else if (items[i].weight > j) {
      dp[i][j] = dp[i - 1][j];
    } else {
      dp[i][j] = Math.max(
        dp[i - 1][j],
        items[i].profit + dp[i - 1][j - items[i].weight]
      );
    }
  }
}

console.log("Max Profit: ", dp[items.length - 1][max_weight]);

let solution = [];
let i = items.length - 1;
let j = max_weight;
let remain = max_weight;

while (remain > 0 && j > 0) {
  if (dp[i][j] > dp[i - 1][j]) {
    solution.push(items[i].name);
    remain -= items[i].weight;
    j = remain;
    i--;
  } else {
    i--;
  }
}

console.log(solution);
