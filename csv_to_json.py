import pandas as pd
import json

# Read the CSV file
df = pd.read_csv("imdb_top_1000.csv")

# Create a list to store the transformed movies
movies = []

# Map CSV columns to our Movie model structure
for _, row in df.iterrows():
    movie = {
        "title": row["Series_Title"][:200],  # Limit to 200 chars
        "year": (
            int(row["Released_Year"]) if row["Released_Year"].isdigit() else None
        ),  # Handle non-numeric years
        "genre": row["Genre"][:100],  # Limit to 100 chars
        "rating": float(row["IMDB_Rating"]),  # Convert to decimal
        "description": (
            row["Overview"][:1000] if pd.notna(row["Overview"]) else None
        ),  # Limit to 1000 chars
    }
    movies.append(movie)

# Write to JSON file
with open("movies_seed.json", "w", encoding="utf-8") as f:
    json.dump(movies, f, ensure_ascii=False, indent=2)

print(f"Converted {len(movies)} movies to JSON format")
