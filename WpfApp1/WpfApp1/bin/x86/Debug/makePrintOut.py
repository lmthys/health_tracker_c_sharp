# SQLiteToPDFWithNamedTuples.py
# Author: Vasudev Ram - http://www.dancingbison.com
# SQLiteToPDFWithNamedTuples.py is a program to demonstrate how to read 
# SQLite database data and convert it to PDF. It uses the Python
# data structure called namedtuple from the collections module of 
# the Python standard library.

from __future__ import print_function
import sys
from collections import namedtuple
import sqlite3
from fpdf import FPDF
import os


try:

    # Create the stocks database.
    conn = sqlite3.connect('MyDatabase.sqlite')
    # Get a cursor to it.
    curs = conn.cursor()

    # Create a namedtuple to represent stock rows.
    Feeling = namedtuple('feeling_table', 'date, feeling_score')
    Sleeping = namedtuple('sleeping_table', 'date, hours_slept')
    Exercise = namedtuple('exercise_table', 'date, hours_exercise')
    Eating = namedtuple('eating_table', 'date, meal, calories_eaten')

    # Run the query to get the stocks data.
    curs.execute("SELECT date, feeling_score FROM feeling_table")

    # Create a PDFWriter and set some of its fields.
    pdf = FPDF(format='letter')
    pdf.alias_nb_pages()
    pdf.add_page()
    
	  # Add an address
    pdf.set_font('Arial', 'B', 15)
    pdf.cell(200, 10, 'Health Report', ln=1, align="C")
 
    # Line break
    pdf.ln(20)
    
    pdf.set_font("Courier", size=12)
    # Now loop over the fetched data and write it to PDF.
    # Map the StockRecord namedtuple's _make class method
    # (that creates a new instance) to all the rows fetched.
    line_no = 1
    row = "Date                     Feeling Score "
    pdf.cell(0,10, txt=row.format(line_no), ln=1)
    
    for feeling in map(Feeling._make, curs.fetchall()):
        row = [ str(col).rjust(10) + " " for col in (feeling.date, \
        feeling.feeling_score) ]
          # Above line can instead be written more simply as:
          # row = [ str(col).rjust(10) + " " for col in stock ]
        row_str = ''.join(row)
        pdf.cell(0,10, txt=row_str.format(line_no), ln=1)
        line_no += 1
    
    # Run the query to get the stocks data.
    curs.execute("SELECT date, hours_slept FROM sleeping_table")

    row = "Date                     Hours Slept "
    pdf.cell(0,10, txt=row.format(1), ln=1)

    for sleeping in map(Sleeping._make, curs.fetchall()):
        row = [ str(col).rjust(10) + " " for col in (sleeping.date, \
        sleeping.hours_slept) ]
          # Above line can instead be written more simply as:
          # row = [ str(col).rjust(10) + " " for col in stock ]
        row_str = ''.join(row)
        pdf.cell(0,10, txt=row_str.format(line_no), ln=1)
        line_no += 1
    
    # Run the query to get the stocks data.
    curs.execute("SELECT date, hours_exercise FROM exercise_table")

    row = "Date                     Hours Exercised "
    pdf.cell(0,10, txt=row.format(1), ln=1)

    for exercise in map(Exercise._make, curs.fetchall()):
        row = [ str(col).rjust(10) + " " for col in (exercise.date, \
        exercise.hours_exercise) ]
          # Above line can instead be written more simply as:
          # row = [ str(col).rjust(10) + " " for col in stock ]
        row_str = ''.join(row)
        pdf.cell(0,10, txt=row_str.format(line_no), ln=1)
        line_no += 1
    
    # Run the query to get the stocks data.
    curs.execute("SELECT date, meal, calories_eaten FROM eating_table")

    row = "Date                    Meal        Calories Eaten "
    pdf.cell(0,10, txt=row.format(1), ln=1)

    for eating in map(Eating._make, curs.fetchall()):
        row = [ str(col).rjust(10) + " " for col in (eating.date, \
        eating.meal, eating.calories_eaten) ]
          # Above line can instead be written more simply as:rm
          # row = [ str(col).rjust(10) + " " for col in stock ]
        row_str = ''.join(row)
        pdf.cell(0,10, txt=row_str.format(line_no), ln=1)
        line_no += 1
    
    pdf.output("health.pdf")
finally:
  conn.close()