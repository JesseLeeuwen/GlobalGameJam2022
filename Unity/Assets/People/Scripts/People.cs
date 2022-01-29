using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "People")]
public class People : ScriptableObject
{
    public List<Customer> customers;

    public Customer GetNext()
    {
        // return the most urgent customer from the queue
        Customer customer = customers[0];
        customers.RemoveAt(0);
        return customer;
    }

    public void ReturnToPool(Customer customer)
    {
        // TODO: change to weighted insertion of return customers 
        // based on newly applied effects
        customers.Add(customer);
    }
}
