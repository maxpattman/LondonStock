Feature: 

A short summary of the feature

@tag1
Scenario: Get Stock By Ticker Symbol
	Given Request for current value of stock TickerSymbol=("*") GET current value of stock
	Then The Response should be a success

#@tag1
#Scenario: Get all Stocks List<{Name:Value}> on the Market
#	Given Request for all stocks * GET current values of all stocks on the market
#	Then The Response should be a success
#
#
#@tag1
#Scenario: Get Specified List of Stocks 
#	Given Request for list of stocks with supplied list of TickerSymbols (*) GET current values of requested stocks
#	When [action]
#	Then The Response should be a success
#

